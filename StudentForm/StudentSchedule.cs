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
    public partial class StudentSchedule : UserControl
    {
        List<Row> listRows = new List<Row>();
        Student student;
        string day;
        public StudentSchedule(Student student)
        {
            InitializeComponent();
            this.student = student;
            day = DateTime.Now.DayOfWeek.ToString();
        }

        private void StudentSchedule_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMonday_Click(object sender, EventArgs e)
        {
            day = "Monday";
            Load_List_View();
        }


        private void btnTuesday_Click(object sender, EventArgs e)
        {
            day = "Tuesday";
            Load_List_View();

        }

        private void btnWednesday_Click(object sender, EventArgs e)
        {
            day = "Wednesday";
            Load_List_View();

        }

        private void btnThursday_Click(object sender, EventArgs e)
        {
            day = "Thursday";
            Load_List_View();
        }

        private void btnFriday_Click(object sender, EventArgs e)
        {
            day = "Friday";
            Load_List_View();
        }

        private void btnSaturday_Click(object sender, EventArgs e)
        {
            day = "Saturday";
            Load_List_View();
        }

        private void btnSunday_Click(object sender, EventArgs e)
        {
            day = "Sunday";
            Load_List_View();
        }

        public void Load_List_View()
        {
            listRows.Clear();

            //Get all columns & rows from StudentModules
            StudentModule_Table studentModule_Table = Programming_Café_DB.studentModuleTable;
            Module_Table ModuleTable = Programming_Café_DB.moduleTable;
            Column columnToSearch = Programming_Café_DB.studentModuleTable.StudentId;
            Column columnToReturn;
            List<Row> studentModuleRows = studentModule_Table.Rows;
            List<Row> SortedByStudent = Programming_Café_DB.studentModuleTable.Search_Row_For_Value(columnToSearch, student.Id);
            

            List<Column> newColumns = new List<Column>
            {
                new Column ("Module"),
                studentModule_Table.Level,
                studentModule_Table.ClassId,
                new Column ("Trainer"),
                new Column ("Start Hour"),
                new Column ("End Hour")
            };

            List<Row> newRows = new List<Row>();
            foreach (Row row in SortedByStudent)
            {
                //Get classId from student module table
                string classId = row.values[studentModule_Table.ClassId];
                if(classId != "0" || classId != null)
                {
                    //Get schedule day from the classTable
                    columnToSearch = Programming_Café_DB.classTable.Id;
                    columnToReturn = Programming_Café_DB.classTable.ScheduleDay;
                    string scheduleDay = Programming_Café_DB.classTable.Get_ColumnValue_From_Row(columnToSearch, classId, columnToReturn);

                    //Check if the schedule day is the same as the selected day
                    if(scheduleDay == day)
                    {
                        //Get StartHour and EndHour
                        columnToReturn = Programming_Café_DB.classTable.StartHour;
                        string startHour = Programming_Café_DB.classTable.Get_ColumnValue_From_Row(columnToSearch, classId, columnToReturn);

                        columnToReturn = Programming_Café_DB.classTable.EndHour;
                        string endHour = Programming_Café_DB.classTable.Get_ColumnValue_From_Row(columnToSearch, classId, columnToReturn);


                        //Get trainerId from the current class
                        columnToReturn = Programming_Café_DB.classTable.TrainerId;
                        string trainerId = Programming_Café_DB.classTable.Get_ColumnValue_From_Row(columnToSearch, classId, columnToReturn);

                        //Get trainerName from trainerId 
                        columnToSearch = Programming_Café_DB.trainerTable.Id;
                        columnToReturn = Programming_Café_DB.trainerTable.Name;
                        string trainerName = Programming_Café_DB.trainerTable.Get_ColumnValue_From_Row(columnToSearch, trainerId, columnToReturn);


                        StudentModule_Table studentModuleTable = Programming_Café_DB.studentModuleTable;

                        //Get Module Name From ModuleTable based on the class' moduleId
                        columnToSearch = Programming_Café_DB.moduleTable.Id;
                        columnToReturn = Programming_Café_DB.moduleTable.Name;
                        string ModuleId = row.values[studentModule_Table.ModuleId];
                        string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, ModuleId, columnToReturn);

                        //Get Level from the current row on the studentModule_Table
                        string Level = row.values[studentModule_Table.Level];

                                List<string> arr_values = new List<string>
                                {
                                    ModuleName,
                                    Level,
                                    classId,
                                    trainerName,
                                    startHour,
                                    endHour
                                };

                                newRows.Add(new Row("", newColumns, arr_values));
                                listRows.Add(row);
                            
                        
                    }
                }
            }
            List<string> columnsToInclude = new List<string>
                {
                    "Module",
                    "Level",
                    "ClassId",
                    "Trainer",
                    "Start Hour",
                    "End Hour"
                };
            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);

        }
    }
}
