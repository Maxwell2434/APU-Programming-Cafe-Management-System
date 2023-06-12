using APU_Programming_Café_Management_System.Tables;
using APU_Programming_Café_Management_System.TrainerForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerStudents : UserControl
    {
        List<Row> listRows = new List<Row>();
        public LecturerStudents()
        {
            InitializeComponent();
        }
        private void LecturerStudents_Load(object sender, EventArgs e)
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
            Column columnToSearch;
            Column columnToReturn;
            List<Row> studentModuleRows = studentModule_Table.Rows;
            List<Row> SortedByModules = new List<Row>();
            if (cmbBoxModule.Text != "All")
            {

                columnToSearch = ModuleTable.Name;
                columnToReturn = ModuleTable.Id;
                foreach (Row row in studentModuleRows)
                {
                    if (row.values[studentModule_Table.ModuleId] == ModuleTable.Get_ColumnValue_From_Row(columnToSearch, cmbBoxModule.Text, columnToReturn))
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
                new Column ("Student"),
                studentModule_Table.ClassId,
                new Column ("Payment"),
                new Column ("Month of Enrollment"),

            };

            List<Row> SortedRows = SortedByLevel;
            List<Row> newRows = new List<Row>();
            foreach (Row row in SortedRows)
            {
                string classId = row.values[studentModule_Table.ClassId];
                StudentModule_Table studentModuleTable = Programming_Café_DB.studentModuleTable;

                //Get Module Name From ModuleTable based on the class' moduleId
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleId = row.values[studentModule_Table.ModuleId];
                string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, ModuleId, columnToReturn);

                //Get Level from the current row on the studentModule_Table
                string Level = row.values[studentModule_Table.Level];



                columnToSearch = studentModuleTable.ClassId;
                List<Row> studentModuleRowsByClassId = studentModuleTable.Search_Row_For_Value(columnToSearch, classId);
                string StudentName = "";
                string PaymentStatus = "";
                string EnrollmentDate = "";
                foreach (Row studentModuleRow in studentModuleRowsByClassId)
                {
                    //If the module name and level is equal to the classTable values
                    if (studentModuleRow.values[studentModuleTable.ModuleId] == ModuleId && studentModuleRow.values[studentModuleTable.Level] == Level)
                    {
                        //Get Payment Status and Enrollment Date of student based on the current row
                        string StudentId = studentModuleRow.values[studentModuleTable.StudentId];
                        columnToSearch = Programming_Café_DB.studentTable.Id;
                        columnToReturn = Programming_Café_DB.studentTable.Name;
                        StudentName = Programming_Café_DB.studentTable.Get_ColumnValue_From_Row(columnToSearch, StudentId, columnToReturn);
                        PaymentStatus = studentModuleRow.values[studentModuleTable.PaymentStatus];
                        EnrollmentDate = studentModuleRow.values[studentModuleTable.EnrollmentMonth];

                        if (StudentName == "" || StudentName == null) { StudentName = "No Students"; }

                        string classValue;
                        if(classId == "0" || classId == null)
                        {
                            classValue = "No Class";
                        }
                        else
                        {
                            classValue = classId;
                        }

                        List<string> arr_values = new List<string>
                        {
                            ModuleName,
                            Level,
                            StudentName,
                            classValue,
                            PaymentStatus,
                            EnrollmentDate
                        };

                        newRows.Add(new Row("", newColumns, arr_values));
                        listRows.Add(studentModuleRow);
                    }
                }






            }
            List<string> columnsToInclude = new List<string>
                {
                    "Module",
                    "Level",
                    "Student",
                    "ClassId",
                    "Payment",
                    "Month of Enrollment"
                };
            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);

        }

        private void cmbBoxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxModule.Text != "" && cmbBoxLevel.Text != "")
            {
                Load_List_View();
            }
        }

        private void cmbBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxModule.Text != "" && cmbBoxLevel.Text != "")
            {
                Load_List_View();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LecturerStudentsAdd lecturerStudentsAdd = new LecturerStudentsAdd(this);
            LecturerUI.Initialize_UserControl(lecturerStudentsAdd, Controls);
            lecturerStudentsAdd.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

            //Delete the studentModule entry based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {
                bool studentIsInMultipleModules = false;
                string studentId = listRows[itemIndexes[i]].values[Programming_Café_DB.studentModuleTable.StudentId];
                if(Programming_Café_DB.studentModuleTable.Search_Row_For_Value(Programming_Café_DB.studentModuleTable.StudentId, studentId).Count > 1)
                {
                    studentIsInMultipleModules = true;
                }

                Programming_Café_DB.studentModuleTable.Del_Row(listRows[itemIndexes[i]]);
                
                //If student doesnt have other modules enrolled then delete the subsequent student and user from the tables
                if (!studentIsInMultipleModules)
                {
                    Row studentRowToBeDeleted = Programming_Café_DB.studentTable.Search_Row_For_Value(Programming_Café_DB.studentTable.Id, studentId)[0];

                    Column columnToSearch = Programming_Café_DB.studentTable.Id;
                    Column columnToReturn = Programming_Café_DB.studentTable.UserId;
                    string userId = Programming_Café_DB.studentTable.Get_ColumnValue_From_Row(columnToSearch, studentId, columnToReturn);
                    Row userRowToBeDeleted = Programming_Café_DB.userTable.Search_Row_For_Value(Programming_Café_DB.userTable.Id, userId)[0];
                    Programming_Café_DB.studentTable.Del_Row(studentRowToBeDeleted);
                    Programming_Café_DB.userTable.Del_Row(userRowToBeDeleted);
                }

                //Update ListView
                Load_List_View();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }
            if(itemIndexes.Count == 1)
            {
                Row rowSelected = listRows[itemIndexes[0]];
                LecturerStudentsUpdate lecturerStudentsUpdate = new LecturerStudentsUpdate(rowSelected, this);
                LecturerUI.Initialize_UserControl(lecturerStudentsUpdate, Controls);
                lecturerStudentsUpdate.BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a Student");
            }

        }
    }
}
