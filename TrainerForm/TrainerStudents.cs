using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.TrainerForm
{
    public partial class TrainerStudents : UserControl
    {
        Trainer trainer;
        public TrainerStudents(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void TrainerStudents_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Students Handled by " + trainer.Name;

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
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            Module_Table ModuleTable = Programming_Café_DB.moduleTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch = ClassTable.TrainerId;
            Column columnToReturn;
            List<Row> classRowsByTrainerId = ClassTable.Search_Row_For_Value(columnToSearch, trainer.Id);
            List<Row> SortedByModules = new List<Row>();
            if (cmbBoxModule.Text != "All")
            {
                
                columnToSearch = ModuleTable.Name;
                columnToReturn = ModuleTable.Id;
                foreach (Row row in classRowsByTrainerId)
                {
                    if (row.values[ClassTable.ModuleId] == ModuleTable.Get_ColumnValue_From_Row(columnToSearch, cmbBoxModule.Text, columnToReturn))
                    {
                        SortedByModules.Add(row);
                    }
                }
            }
            else
            {
                SortedByModules = classRowsByTrainerId;
            }

            List<Row> SortedByLevel = new List<Row>();
            if(cmbBoxLevel.Text != "All")
            {
                foreach(Row row in SortedByModules)
                {
                    if (row.values[ClassTable.Level] == cmbBoxLevel.Text)
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
                ClassTable.Level,
                new Column ("Student"),
                new Column ("Payment"),
                new Column ("Month of Enrollment"),

            };

            List<Row> SortedRows = SortedByLevel;
            List<Row> newRows = new List<Row>();
            foreach (Row row in SortedRows)
            {
                string classId = row.values[ClassTable.Id];
                StudentModule_Table studentModuleTable = Programming_Café_DB.studentModuleTable;

                //Get Module Name From ModuleTable based on the class' moduleId
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleId = row.values[ClassTable.ModuleId];
                string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, ModuleId, columnToReturn);
                
                //Get Level from the current row on the ClassTable
                string Level = row.values[ClassTable.Level];

                
                
                columnToSearch = studentModuleTable.ClassId;
                List<Row> studentModuleRowsByClassId = studentModuleTable.Search_Row_For_Value(columnToSearch, classId);
                string StudentName="";
                string PaymentStatus="";
                string EnrollmentDate="";
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

                        List<string> arr_values = new List<string>
                        {
                            ModuleName,
                            Level,
                            StudentName,
                            PaymentStatus,
                            EnrollmentDate
                        };

                        newRows.Add(new Row("", newColumns, arr_values));
                    }
                }
                

               

                

            }
            List<string> columnsToInclude = new List<string>
                {
                    "Module",
                    "Level",
                    "Student",
                    "Payment",
                    "Month of Enrollment"
                };
            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);

        }

        private void cmbBoxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxModule.Text!= "" && cmbBoxLevel.Text != "")
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
    }
}
