using APU_Programming_Café_Management_System.AdminForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APU_Programming_Café_Management_System
{
    public partial class TrainerList : UserControl
    {
        public TrainerList()
        {
            InitializeComponent();
        }

        private void TrainerList_Load(object sender, EventArgs e)
        {
            Load_Trainer_ListView();
        }

        public void Load_Trainer_ListView()
        {
            List<Column> columns = Programming_Café_DB.trainerTable.Columns;
            List<Row> rows = Programming_Café_DB.trainerTable.Rows;
            List<string> columnsToInclude = new List<string>
            {
                "Name",
                "Address",
                "Phone",
                "Email"
            };
            AdminUI.SetupListView(lstViewTrainer, columns, rows, columnsToInclude);
        }

        



        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerListAdd trainerListAdd = new TrainerListAdd(this);
            AdminUI.Initialize_UserControl(trainerListAdd, Controls);
            trainerListAdd.BringToFront();

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

            //Delete the trainer and its related dependencies based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for(int i = itemIndexes.Count-1; i >= 0; i--)
            {
                string trainerId = Programming_Café_DB.trainerTable.Rows[itemIndexes[i]].values[Programming_Café_DB.trainerTable.Id];
                Column columnToSearch = Programming_Café_DB.classTable.TrainerId;


                //Delete the dependencies of the trainer on the classes table
                List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.SearchRowForValue(columnToSearch, trainerId);
                foreach (Row row in classRowsByTrainerId)
                {
                    Programming_Café_DB.classTable.DelRow(row);
                }

                //Delete the trainer from the Feedback table
                columnToSearch = Programming_Café_DB.feedbackTable.TrainerId;
                List<Row> feedbackRowsByTrainerId = Programming_Café_DB.feedbackTable.SearchRowForValue(columnToSearch, trainerId);
                foreach (Row row in feedbackRowsByTrainerId)
                {
                    Programming_Café_DB.feedbackTable.DelRow(row);
                }

                //Get userId from the associated trainer from trainerTable
                columnToSearch = Programming_Café_DB.trainerTable.Id;
                Column columnToReturn = Programming_Café_DB.trainerTable.UserId;
                string userId = Programming_Café_DB.trainerTable.GetColumnValueFromRow(columnToSearch, trainerId, columnToReturn);

                //Delete the trainer from the trainerTable and Database
                columnToSearch = Programming_Café_DB.trainerTable.Id;
                List<Row> rows = Programming_Café_DB.trainerTable.SearchRowForValue(columnToSearch, trainerId);
                Programming_Café_DB.trainerTable.DelRow(rows[0]);

                //Delete the trainer from the User table using the userId
                columnToSearch = Programming_Café_DB.userTable.Id;
                List<Row> userRowsByUserId = Programming_Café_DB.userTable.SearchRowForValue(columnToSearch, userId);
                foreach (Row row in userRowsByUserId)
                {
                    Programming_Café_DB.userTable.DelRow(row);
                }



                //Update ListView
                Load_Trainer_ListView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lstViewTrainer.CheckedItems.Count == 1)
            {
                //Gets trainerId by looking at the first index of the subitems
                string trainerName = lstViewTrainer.CheckedItems[0].SubItems[0].Text;
                Column columnToSearch = Programming_Café_DB.trainerTable.Name;
                Column columnToReturn = Programming_Café_DB.trainerTable.Id;
                string trainerId = Programming_Café_DB.trainerTable.GetColumnValueFromRow(columnToSearch, trainerName, columnToReturn);
                TrainerEdit trainerEdit = new TrainerEdit(trainerId);
                AdminUI.Initialize_UserControl(trainerEdit, Controls);
                trainerEdit.BringToFront();
            }
            else
            {
                MessageBox.Show("Please Select a Trainer");
            }
        }


    }
}
