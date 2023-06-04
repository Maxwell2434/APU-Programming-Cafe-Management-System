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
        List<string> trainerIds;
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
            SetupListView(lstViewTrainer, columns, rows, columnsToInclude);
        }

        public static void SetupListView(System.Windows.Forms.ListView lstView, List<Column> columns, List<Row> rows, List<string> columnsToInclude)
        {
            //Clear the List
            lstView.Clear();
            //Set the view to show details.
            lstView.View = View.Details;
            //Display check boxes.
            lstView.CheckBoxes = true;
            //Select the item and subitems when selection is made.
            lstView.FullRowSelect = true;
            //Display grid lines.
            lstView.GridLines = true;
            
            List<int> indexes = new List<int>();
            for(int i = 0; i < columns.Count; i++)
            {
                //Checks if the column is in the columnsToInclude if it is then add the column to the ListView
                if (columnsToInclude.Contains(columns[i].Name))
                {
                    lstView.Columns.Add(columns[i].Name);
                    indexes.Add(i);
                }
            }


            foreach (Row row in rows)
            {
                List<string> values = new List<string>();
                string[] arr_value = row.Get_Value_Arr();
                for (int i = 0; i < indexes.Count; i++)
                {
                    values.Add(arr_value[indexes[i]]);
                }
                lstView.Items.Add(new ListViewItem(values.ToArray()));
            }

            //Resize the columns to match the content size
            lstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerListAdd trainerListAdd = new TrainerListAdd(this);
            AdminUI.Initialize_UserControl(trainerListAdd, Controls);
            trainerListAdd.BringToFront();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (ListViewItem item in lstViewTrainer.Items)
            {
                if (item.Checked || item.Selected)
                {
                    
                    string trainerId = Programming_Café_DB.trainerTable.Rows[item.Index+i].values[Programming_Café_DB.trainerTable.Id];
                    Column columnToSearch = Programming_Café_DB.classTable.TrainerId;


                    //Delete the dependencies of the trainer on the classes table
                    List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.Search_Row_For_Value(columnToSearch, trainerId);
                    foreach(Row row in classRowsByTrainerId)
                    {
                        Programming_Café_DB.classTable.Del_Row(row);
                    }
                    columnToSearch = Programming_Café_DB.trainerTable.Id;
                    Column columnToReturn = Programming_Café_DB.trainerTable.UserId;
                    string userId = Programming_Café_DB.trainerTable.Get_ColumnValue_From_Row(columnToSearch, trainerId, columnToReturn);

                    //Delete the trainer from the trainerTable and Database
                    columnToSearch = Programming_Café_DB.trainerTable.Id;
                    List<Row> rows = Programming_Café_DB.trainerTable.Search_Row_For_Value(columnToSearch, trainerId);
                    Programming_Café_DB.trainerTable.Del_Row(rows[0]);

                    //Delete the trainer from the User table 
                    columnToSearch = Programming_Café_DB.userTable.Id;
                    List<Row> userRowsByUserId = Programming_Café_DB.userTable.Search_Row_For_Value(columnToSearch, userId);
                    foreach(Row row in userRowsByUserId)
                    {
                        Programming_Café_DB.userTable.Del_Row(row);
                    }

                    

                    //Update ListView
                    Load_Trainer_ListView();
                    i++;
                }
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
                string trainerId = Programming_Café_DB.trainerTable.Get_ColumnValue_From_Row(columnToSearch, trainerName, columnToReturn);
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
