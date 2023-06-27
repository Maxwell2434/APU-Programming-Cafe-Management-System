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
    public partial class AdminFeedback : UserControl
    {
        Trainer trainer;
        public AdminFeedback(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void AdminFeedback_Load(object sender, EventArgs e)
        {
            Load_ListView();
        }

        public void Load_ListView()
        {
            lstViewTrainer.Items.Clear();
            //Get all columns & rows from matching trainerId from feedbackTable
            Feedback_Table feedbackTable = Programming_Café_DB.feedbackTable;
            Administrator_Table administrator = Programming_Café_DB.administratorTable;
            Column columnToSearch = feedbackTable.TrainerId;

            string trainerId = trainer.Id;
            List<Row> rows = feedbackTable.SearchRowForValue(columnToSearch, trainerId);

            List<Column> newColumns = new List<Column>
            {
                administrator.Name,
                feedbackTable.Feedback
            };


            columnToSearch = administrator.Id;
            Column columnToReturn = administrator.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                string AdministratorName = administrator.GetColumnValueFromRow(columnToSearch, rows[i].values[feedbackTable.AdministratorId], columnToReturn);
                string Feedback = rows[i].values[feedbackTable.Feedback];
                List<string> arr_values = new List<string>
                {
                    AdministratorName,
                    Feedback
                };

                newRows.Add(new Row("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Name",
                "Feedback",
            };

            AdminUI.SetupListView(lstViewTrainer, newColumns, newRows, columnsToInclude);




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Record the indexes of the checked || selected items in the ListView
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstViewTrainer.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }


            Feedback_Table feedbackTable = Programming_Café_DB.feedbackTable;
            Column columnToSearch = feedbackTable.TrainerId;
            List<Row> feedbackRowsByTrainerId = feedbackTable.SearchRowForValue(columnToSearch, trainer.Id);


            //Delete the feedback based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {
                Programming_Café_DB.feedbackTable.DelRow(feedbackRowsByTrainerId[itemIndexes[i]]);
            }

            Load_ListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminFeedbackAdd adminFeedbackAdd = new AdminFeedbackAdd(trainer, this);
            AdminUI.Initialize_UserControl(adminFeedbackAdd, Controls);
            adminFeedbackAdd.BringToFront();
        }
    }
}
