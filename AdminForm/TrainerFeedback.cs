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

namespace APU_Programming_Café_Management_System.AdminForm
{
    public partial class TrainerFeedback : UserControl
    {
        private Administrator administrator;
        public TrainerFeedback(Administrator administrator)
        {
            InitializeComponent();
            this.administrator = administrator;
        }

        private void btnRead_Click(object sender, EventArgs e)
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
            Column columnToSearch = feedbackTable.AdministratorId;
            List<Row> feedbackRowsByAdministratorId = feedbackTable.Search_Row_For_Value(columnToSearch, administrator.Id);


            //Delete the feedback based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {
                Programming_Café_DB.feedbackTable.Del_Row(feedbackRowsByAdministratorId[itemIndexes[i]]);
            }

            Load_ListView();
        }
            
        

        private void TrainerFeedback_Load(object sender, EventArgs e)
        {
            Load_ListView();
        }

        public void Load_ListView()
        {
            lstViewTrainer.Items.Clear();
            //Get all columns & rows from matching adminId from feedbackTable
            Feedback_Table feedbackTable = Programming_Café_DB.feedbackTable;
            Trainer_Table trainerTable = Programming_Café_DB.trainerTable;
            Column columnToSearch = feedbackTable.AdministratorId;

            List<Row> rows = feedbackTable.Search_Row_For_Value(columnToSearch, administrator.Id);

            List<Column> newColumns = new List<Column>
            {
                trainerTable.Name,
                feedbackTable.Feedback
            };


            columnToSearch = trainerTable.Id;
            Column columnToReturn = trainerTable.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                string TrainerName = trainerTable.Get_ColumnValue_From_Row(columnToSearch, rows[i].values[feedbackTable.TrainerId], columnToReturn);
                string Feedback = rows[i].values[feedbackTable.Feedback];
                List<string> arr_values = new List<string>
                {
                    TrainerName,
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


    }
}
