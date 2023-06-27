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
    public partial class AdminFeedbackAdd : UserControl
    {
        Trainer trainer;
        AdminFeedback adminFeedback;
        public AdminFeedbackAdd(Trainer trainer, AdminFeedback adminFeedback)
        {
            InitializeComponent();
            this.trainer = trainer;
            this.adminFeedback = adminFeedback;
        }


        private void btnWrite_Click(object sender, EventArgs e)
        {
            Column columnToSearch = Programming_Café_DB.administratorTable.Name;
            string adminName = cmbBoxAdmin.SelectedItem.ToString();
            Column columnToReturn = Programming_Café_DB.administratorTable.Id;
            string adminId = Programming_Café_DB.administratorTable.GetColumnValueFromRow(columnToSearch, adminName, columnToReturn);

            List<string> values = new List<string>
            {
                //Id
                "",

                //TrainerId
                trainer.Id,

                //AdministratorID
                adminId,

                //Feedback
                rchTxtBoxFeedback.Text,
            };

            Programming_Café_DB.feedbackTable.InsertRow(values, Programming_Café_DB.feedbackTable.Columns);
            adminFeedback.Load_ListView();
            this.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void AdminFeedbackAdd_Load(object sender, EventArgs e)
        {
            foreach(Row row in Programming_Café_DB.administratorTable.Rows)
            {
                string administratorName = row.values[Programming_Café_DB.administratorTable.Name];
                cmbBoxAdmin.Items.Add(administratorName);
            }
            
        }
    }
}
