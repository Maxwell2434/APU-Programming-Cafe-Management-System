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
    public partial class TrainerClassesUpdate : UserControl
    {
        TrainerClasses trainerClasses;
        Trainer trainer;
        Row selectedRow;
        public TrainerClassesUpdate(TrainerClasses trainerClasses, Trainer trainer, Row selectedRow)
        {
            InitializeComponent();
            this.trainerClasses = trainerClasses;
            this.trainer = trainer;
            this.selectedRow = selectedRow;
            foreach (Row row in Programming_Café_DB.moduleTable.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.moduleTable.Name]);
            }
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");
            this.trainer = trainer;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            //Check if trainer has any conflicting schedules
            bool conflictingSchedule = false;
            Class_Table classTable = Programming_Café_DB.classTable;
            Column columnToSearch = Programming_Café_DB.trainerTable.Id;
            List<Row> classesRowsByTrainerId = classTable.Search_Row_For_Value(columnToSearch, trainer.Id);
            foreach(Row row in classesRowsByTrainerId)
            {
                //Check if any rows contain the same date as the one selected in the comboBox
                if(row.values.ContainsValue(cmbBoxScheduleDay.Text))
                {
                    //If so, check if either the start hour or end hour is the same
                    if (row.values[classTable.StartHour] == cmbBoxStartHour.Text || row.values[classTable.EndHour] == cmbBoxEndHour.Text)
                    {
                        //If yes then it is a conflicting schedule
                        MessageBox.Show("Conflicting Class Schedule, trainer already has another class in the same time frame");
                        conflictingSchedule= true;
                    }

                }

            }

            if(!conflictingSchedule)
            {
                bool ModuleandLevelExists = false;
                string moduleId = "";
                //Check if trainer already has another class with the same module and level
                foreach(Row row in classesRowsByTrainerId)
                {
                    columnToSearch = Programming_Café_DB.moduleTable.Name;
                    Column columnToReturn = Programming_Café_DB.moduleTable.Id;
                    moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, cmbBoxModule.Text, columnToReturn);
                    
                    if (row.values[classTable.ModuleId] == moduleId && row.values[classTable.Level] == cmbBoxLevel.Text)
                    {
                        ModuleandLevelExists= true;
                    }
                }

                if(!ModuleandLevelExists)
                {
                    string tableName = classTable.TableName;
                    Dictionary<Column, string> newValues = new Dictionary<Column, string>
                    {
                        { classTable.Id, selectedRow.values[classTable.Id] },
                        { classTable.ModuleId, moduleId },
                        { classTable.TrainerId, trainer.Id },
                        { classTable.Level, cmbBoxLevel.Text },
                        { classTable.ScheduleDay, cmbBoxScheduleDay.Text },
                        { classTable.StartHour, cmbBoxStartHour.Text },
                        { classTable.EndHour, cmbBoxEndHour.Text },
                        { classTable.Fee, cmbBoxFee.Text },
                        { classTable.Duration, selectedRow.values[classTable.Duration] }
                    };
                    Programming_Café_DB.Update_Table_Database(tableName, selectedRow, newValues);
                }
            }


        }


    }
}
