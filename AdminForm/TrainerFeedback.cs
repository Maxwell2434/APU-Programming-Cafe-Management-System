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
            int i = 0;
            foreach (ListViewItem item in lstViewTrainer.Items)
            {
                if (item.Checked || item.Selected)
                {

                    string trainerId = Programming_Café_DB.trainerTable.Rows[item.Index + i].values[Programming_Café_DB.trainerTable.Id];

                    Column columnToSearch = Programming_Café_DB.feedbackTable.TrainerId;
                    List<Row> feedbackRowsByTrainerId = Programming_Café_DB.feedbackTable.Search_Row_For_Value(columnToSearch, trainerId);
                    foreach (Row row in feedbackRowsByTrainerId)
                    {
                        Programming_Café_DB.feedbackTable.Del_Row(row);
                    }
                    i++;
                }
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
            //Get all columns & rows from matching trainerId from classTable
            Feedback_Table feedbackTable = Programming_Café_DB.feedbackTable;
            Trainer_Table trainerTable = Programming_Café_DB.trainerTable;
            Column columnToSearch = feedbackTable.AdministratorId;

            string administratorId = administrator.Id;
            List<Row> rows = feedbackTable.Search_Row_For_Value(columnToSearch, administratorId);

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
