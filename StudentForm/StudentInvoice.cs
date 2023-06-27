using APU_Programming_Café_Management_System.Tables;
using APU_Programming_Café_Management_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.StudentForm
{
    public partial class StudentInvoice : UserControl
    {
        List<Row> listRows = new List<Row>();
        Student student;
        public StudentInvoice(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void StudentInvoice_Load(object sender, EventArgs e)
        {
            cmbBoxModule.Items.Add("All");
            foreach (Row row in Programming_Café_DB.moduleTable.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.moduleTable.Name]);
            }

            cmbBoxLevel.Items.Add("All");
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");

            cmbBoxModule.SelectedIndex = 0;
            cmbBoxLevel.SelectedIndex = 0;
        }

        public void Load_List_View()
        {
            listRows.Clear();

            //Get all columns & rows from StudentModules
            StudentModule_Table studentModule_Table = Programming_Café_DB.studentModuleTable;
            Module_Table ModuleTable = Programming_Café_DB.moduleTable;
            Column columnToSearch = studentModule_Table.StudentId;
            Column columnToReturn;
            List<Row> studentModuleRows = studentModule_Table.SearchRowForValue(columnToSearch, student.Id);
            List<Row> SortedByModules = new List<Row>();
            if (cmbBoxModule.Text != "All")
            {

                columnToSearch = ModuleTable.Name;
                columnToReturn = ModuleTable.Id;
                foreach (Row row in studentModuleRows)
                {
                    if (row.values[studentModule_Table.ModuleId] == ModuleTable.GetColumnValueFromRow(columnToSearch, cmbBoxModule.Text, columnToReturn))
                    {
                        SortedByModules.Add(row);
                    }
                }
            }
            else
            {
                SortedByModules = studentModuleRows;
            }

            List<Row> SortedByLevel = new List<Row>();
            if (cmbBoxLevel.Text != "All")
            {
                foreach (Row row in SortedByModules)
                {
                    if (row.values[studentModule_Table.Level] == cmbBoxLevel.Text)
                    {
                        SortedByLevel.Add(row);
                    }
                }
            }
            else
            {
                SortedByLevel = SortedByModules;
            }

            List<Column> newColumns = new List<Column>
            {
                new Column ("Module"),
                studentModule_Table.Level,
                new Column("ClassId"),
                Programming_Café_DB.classTable.Fee,
                new Column ("Payment"),
                new Column ("Month of Enrollment"),

            };

            List<Row> SortedRows = SortedByLevel;
            List<Row> newRows = new List<Row>();
            foreach (Row row in SortedRows)
            {
                StudentModule_Table studentModuleTable = Programming_Café_DB.studentModuleTable;

                //Get Module Name From ModuleTable based on the class' moduleId
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleId = row.values[studentModule_Table.ModuleId];
                string ModuleName = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, ModuleId, columnToReturn);

                //Get Level from the current row on the studentModule_Table
                string Level = row.values[studentModule_Table.Level];

                //Get Class Fee from the classTable with the classId
                string classId = row.values[studentModule_Table.ClassId];
                columnToSearch = Programming_Café_DB.classTable.Id;
                columnToReturn = Programming_Café_DB.classTable.Fee;
                string fee = Programming_Café_DB.classTable.GetColumnValueFromRow(columnToSearch, classId, columnToReturn);

                columnToSearch = studentModuleTable.ClassId;
                List<Row> studentModuleRowsByClassId = studentModuleTable.SearchRowForValue(columnToSearch, classId);
                string PaymentStatus = "";
                string EnrollmentDate = "";
                foreach (Row studentModuleRow in studentModuleRowsByClassId)
                {
                    //If the module name and level is equal to the classTable values
                    if (studentModuleRow.values[studentModuleTable.ModuleId] == ModuleId && studentModuleRow.values[studentModuleTable.Level] == Level)
                    {
                        //Get Payment Status and Enrollment Date of student based on the current row
                        PaymentStatus = studentModuleRow.values[studentModuleTable.PaymentStatus];
                        EnrollmentDate = studentModuleRow.values[studentModuleTable.EnrollmentMonth];


                        string classValue;
                        if (classId == "0" || classId == null)
                        {
                            classValue = "No Class";
                        }
                        //Only show the entry where there is a class
                        else
                        {
                            classValue = classId;
                            //Only show the entry where the student hasn't paid for the class yet 
                            if (PaymentStatus == "UnPaid")
                            {
                                List<string> arr_values = new List<string>
                                {
                                    ModuleName,
                                    Level,
                                    classValue,
                                    fee,
                                    PaymentStatus,
                                    EnrollmentDate
                                };

                                newRows.Add(new Row("", newColumns, arr_values));
                                listRows.Add(studentModuleRow);
                               
                            }
                        }
                    }
                }
            }
            List<string> columnsToInclude = new List<string>
            {
                "Module",
                "Level",
                "ClassId",
                "Fee",
                "Payment",
                "Month of Enrollment"
            };
            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);


        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Record the indexes of the checked || selected items in the ListView
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }

            //Delete the requestModule entry based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {
                Programming_Café_DB.studentModuleTable.DelRow(listRows[itemIndexes[i]]);
                listRows[itemIndexes[i]].values[Programming_Café_DB.studentModuleTable.PaymentStatus] = "Paid";
                Programming_Café_DB.studentModuleTable.InsertRow(listRows[itemIndexes[i]]);
            }
            Load_List_View();
        }



        private void cmbBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxModule.Text != "" && cmbBoxLevel.Text != "")
            {
                Load_List_View();
            }
        }


        private void cmbBoxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxModule.Text != "" && cmbBoxLevel.Text != "")
            {
                Load_List_View();
            }
        }
    }
}
