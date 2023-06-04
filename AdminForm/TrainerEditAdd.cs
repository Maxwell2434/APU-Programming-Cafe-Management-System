using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.AdminForm
{
    public partial class TrainerEditAdd : UserControl
    {
        private TrainerEdit trainerEdit;
        private string trainerId;
        public TrainerEditAdd(TrainerEdit trainerEdit, string trainerId)
        {
            InitializeComponent();
            this.trainerEdit = trainerEdit;
            this.trainerId = trainerId;
            foreach (Row row in Programming_Café_DB.module_Table.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.module_Table.Name]);
            }
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Column columnToSearch = Programming_Café_DB.module_Table.Name;
            string moduleName = cmbBoxModule.SelectedItem.ToString();
            Column columnToReturn = Programming_Café_DB.module_Table.Id;
            string moduleId = Programming_Café_DB.module_Table.Get_ColumnValue_From_Row(columnToSearch, moduleName, columnToReturn);
            string level = cmbBoxLevel.SelectedItem.ToString();

            List<string> values = new List<string>
            {
                //Id
                "",

                //ModuleId
                moduleId,
                
                //TrainerId
                trainerId,
                
                //ScheduleDay
                "",
                
                //StartHour
                "",
                
                //EndHour
                "",
                
                //Level
                level,
                
                //Fee
                "",
                
                //Duration
                ""
            };

            Programming_Café_DB.classTable.Insert_Row(values);
            trainerEdit.Load_ListView();
            this.Dispose();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }
    }
}
