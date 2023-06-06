using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.TrainerForm
{
    public partial class TrainerClassesAdd : UserControl
    {
        TrainerClasses trainerClasses;
        Trainer trainer;
        public TrainerClassesAdd(TrainerClasses trainerClasses, Trainer trainer)
        {
            InitializeComponent();
            this.trainerClasses = trainerClasses;
            this.trainer = trainer;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get module id from module name
            Column columnToSearch = Programming_Café_DB.moduleTable.Name;
            string moduleName = cmbBoxModule.Text;
            Column columnToReturn = Programming_Café_DB.moduleTable.Id;
            string moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, moduleName, columnToReturn);

            //Get all values first
            List<string> values = new List<string>
            {
                "",
                moduleId,
                trainer.Id,
                cmbBoxLevel.Text,
                cmbBoxScheduleDay.Text,
                cmbBoxStartHour.Text,
                cmbBoxEndHour.Text,
                cmbBoxFee.Text,

            };

            //check if the values contain any empty values
            bool emptyValues = false;
            // i starts with 1 to ignore the first the first value which is always "" due to it being a primary key
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] == null || values[i] == "")
                {
                    emptyValues = true;
                }
            }

            if (emptyValues)
            {
                MessageBox.Show("Empty values are present");
            }
            else
            {
                //Create a dummyRow which is used for nothing other than as a replacement for selectedRow
                Row dummyRow = Programming_Café_DB.moduleTable.Rows[0];
                bool conflictingSchedule = trainerClasses.CheckForConflictingSchedule(dummyRow, cmbBoxScheduleDay.Text, cmbBoxStartHour.Text, cmbBoxEndHour.Text);

                if (!conflictingSchedule)
                {

                    bool ModuleAndLevelExists = trainerClasses.CheckForExistingModulesAndLevels(dummyRow, cmbBoxModule.Text, cmbBoxLevel.Text);

                    if (!ModuleAndLevelExists)
                    {
                        Class_Table classTable = Programming_Café_DB.classTable;
                        List<Column> uniqueColumns = classTable.Columns;
                        Programming_Café_DB.classTable.Insert_Row(values, uniqueColumns);
                        trainerClasses.Load_Classes_ListView();
                        this.Dispose();
                    }
                }

            }
        
            
        }
    }
}
