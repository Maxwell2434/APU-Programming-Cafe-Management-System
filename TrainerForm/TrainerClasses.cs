using APU_Programming_Café_Management_System.AdminForm;
using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.TrainerForm
{
    public partial class TrainerClasses : UserControl
    {
        Trainer trainer;
        public TrainerClasses(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void TrainerClasses_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Classes Handled by " + trainer.Name;
            Load_Classes_ListView();
        }

        public void Load_Classes_ListView()
        {
            lstViewClasses.Items.Clear();
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch = ClassTable.TrainerId;

            List<Row> rows = ClassTable.SearchRowForValue(columnToSearch, trainer.Id);

            List<Column> newColumns = new List<Column>
            {
                new Column("Module"),
                ClassTable.Level,
                ClassTable.ScheduleDay,
                ClassTable.StartHour,
                ClassTable.EndHour,
                ClassTable.Fee
            };


            columnToSearch = Programming_Café_DB.moduleTable.Id;
            Column columnToReturn = Programming_Café_DB.moduleTable.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                string ModuleName = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, rows[i].values[ClassTable.ModuleId], columnToReturn);
                string ScheduleDay = rows[i].values[ClassTable.ScheduleDay];
                string StartHour = rows[i].values[ClassTable.StartHour];
                string EndHour = rows[i].values[ClassTable.EndHour];
                string Level = rows[i].values[ClassTable.Level];
                string Fee = rows[i].values[ClassTable.Fee];
                List<string> arr_values = new List<string>
                {
                    ModuleName,
                    Level,
                    ScheduleDay,
                    StartHour,
                    EndHour,
                    Fee
                };

                newRows.Add(new Row("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Module",
                "Level",
                "ScheduleDay",
                "StartHour",
                "EndHour",
                "Fee"
            };

            AdminUI.SetupListView(lstViewClasses, newColumns, newRows, columnsToInclude);


        }

        public bool CheckForConflictingSchedule(Row selectedRow, string ScheduleDay, string StartHour, string EndHour)
        {
            //Check if trainer has any conflicting schedules
            bool conflictingSchedule = false;
            Class_Table classTable = Programming_Café_DB.classTable;
            Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
            List<Row> classesRowsByTrainerId = classTable.SearchRowForValue(columnToSearch, trainer.Id);
            foreach (Row row in classesRowsByTrainerId)
            {
                if (row != selectedRow)
                {
                    //Check if any rows contain the same date as the one selected in the comboBox
                    if (row.values.ContainsValue(ScheduleDay))
                    {
                        int existingStartHour = Convert.ToInt32(row.values[classTable.StartHour]);
                        int existingEndHour = Convert.ToInt32(row.values[classTable.EndHour]);
                        int selectedStartHour = Convert.ToInt32(StartHour);
                        int selectedEndHour = Convert.ToInt32(EndHour);

                        //Check if the selected End Hour is equal or bigger to the selected Start Hour
                        if (selectedStartHour >= selectedEndHour)
                        {
                            //If yes then it is a conflicting schedule
                            conflictingSchedule = true;
                            MessageBox.Show("Conflicting Class Schedule, trainer already has another class in the same time frame");

                        }
                        
                        //Check if the selected End Hour is inside the timeframe of an existing class time
                        else if (selectedEndHour > existingStartHour && selectedEndHour <= existingEndHour)
                        {
                            //If yes then it is a conflicting schedule
                            conflictingSchedule = true;
                            MessageBox.Show("Conflicting Class Schedule, trainer already has another class in the same time frame");

                        }
                        //Check if the selected Start Hour is inside the timeframe of an existing class time
                        else if (selectedStartHour >= existingStartHour && selectedStartHour < existingEndHour)
                        {
                            //If yes then it is a conflicting schedule
                            conflictingSchedule = true;
                            MessageBox.Show("Conflicting Class Schedule, trainer already has another class in the same time frame");

                        }
                        //Check if the selected Start Hour is earlier and if the selected End Hour is later
                        else if (selectedStartHour < existingStartHour && selectedEndHour > existingEndHour)
                        {
                            //If yes then it is a conflicting schedule
                            conflictingSchedule = true;
                            MessageBox.Show("Conflicting Class Schedule, trainer already has another class in the same time frame");

                        }
                    }
                }
            }
            return conflictingSchedule;
        }

        public bool CheckForExistingModulesAndLevels(Row selectedRow, string moduleName, string level)
        {
            bool ModuleAndLevelExists = false;
            Class_Table classTable = Programming_Café_DB.classTable;
            Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
            List<Row> classesRowsByTrainerId = classTable.SearchRowForValue(columnToSearch, trainer.Id);
            string moduleId = "";
            //Check if trainer already has another class with the same module and level
            foreach (Row row in classesRowsByTrainerId)
            {
                columnToSearch = Programming_Café_DB.moduleTable.Name;
                Column columnToReturn = Programming_Café_DB.moduleTable.Id;
                moduleId = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, moduleName, columnToReturn);

                //if the selected row is not equal to the row in loop
                if (selectedRow != row)
                {
                    //If the row in the loop is not equal to the module and level selected in the combo box
                    if (row.values[classTable.ModuleId] == moduleId && row.values[classTable.Level] == level)
                    {
                        ModuleAndLevelExists = true;
                        MessageBox.Show("Trainer is already handling this module and level");

                    }
                }

            }
            return ModuleAndLevelExists;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerClassesAdd trainerClassesAdd = new TrainerClassesAdd(this, trainer);
            AdminUI.Initialize_UserControl(trainerClassesAdd, Controls);
            trainerClassesAdd.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Record the indexes of the checked || selected items in the ListView
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstViewClasses.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }
            
            Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
            List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.SearchRowForValue(columnToSearch, trainer.Id);

            //Delete the class and its related dependencies based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {

                Programming_Café_DB.classTable.DelRow(classRowsByTrainerId[itemIndexes[i]]);
                //Update ListView
                Load_Classes_ListView();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstViewClasses.CheckedItems.Count == 1)
            {
                Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
                List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.SearchRowForValue(columnToSearch, trainer.Id);
                int index = lstViewClasses.CheckedItems[0].Index;
                

                TrainerClassesUpdate trainerClassesUpdate = new TrainerClassesUpdate(this, trainer, classRowsByTrainerId[index]);
                AdminUI.Initialize_UserControl(trainerClassesUpdate, Controls);
                trainerClassesUpdate.BringToFront();
            }
            else
            {
                MessageBox.Show("Please Select a Class");
            }

            
        }

  
    }
}
