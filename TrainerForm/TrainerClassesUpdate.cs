using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            //Check if trainer has any conflicting schedules
            bool conflictingSchedule = trainerClasses.CheckForConflictingSchedule(selectedRow, cmbBoxScheduleDay.Text, cmbBoxStartHour.Text, cmbBoxEndHour.Text);
            
            if(!conflictingSchedule)
            {
                bool ModuleAndLevelExists = trainerClasses.CheckForExistingModulesAndLevels(selectedRow, cmbBoxModule.Text, cmbBoxLevel.Text);

                if(!ModuleAndLevelExists)
                {
                    Class_Table classTable = Programming_Café_DB.classTable;
                    string tableName = classTable.TableName;
                    Column columnToSearch = Programming_Café_DB.moduleTable.Name;
                    string moduleName = cmbBoxModule.Text;
                    Column columnToReturn = Programming_Café_DB.moduleTable.Id;
                    string moduleId = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, moduleName, columnToReturn);

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
                    Programming_Café_DB.UpdateTableDatabase(tableName, selectedRow, newValues);
                    Programming_Café_DB.classTable.RefreshTableValues();
                    trainerClasses.Load_Classes_ListView();
                    this.Dispose();
                }

            }


        }

        private void TrainerClassesUpdate_Load(object sender, EventArgs e)
        {
            string moduleId = selectedRow.values[Programming_Café_DB.classTable.ModuleId];
            Column columnToSearch = Programming_Café_DB.moduleTable.Id;
            Column columnToReturn = Programming_Café_DB.moduleTable.Name;
            string moduleName = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, moduleId, columnToReturn);
            cmbBoxModule.Text = moduleName;

            cmbBoxLevel.Text = selectedRow.values[Programming_Café_DB.classTable.Level];
            cmbBoxScheduleDay.Text = selectedRow.values[Programming_Café_DB.classTable.ScheduleDay];
            cmbBoxStartHour.Text = selectedRow.values[Programming_Café_DB.classTable.StartHour];
            cmbBoxEndHour.Text = selectedRow.values[Programming_Café_DB.classTable.EndHour];
            cmbBoxFee.Text = selectedRow.values[Programming_Café_DB.classTable.Fee];
            

        }
    }
}
