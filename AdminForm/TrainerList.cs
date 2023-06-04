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
            SetupListView(lstViewTrainer, columns, rows, columnsToInclude);
        }

        public static void SetupListView(System.Windows.Forms.ListView lstView, List<Column> columns, List<Row> rows, List<string> columnsToInclude)
        {
            lstView.Clear();
            // Set the view to show details.
            lstView.View = View.Details;
            // Display check boxes.
            lstView.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            lstView.FullRowSelect = true;
            // Display grid lines.
            lstView.GridLines = true;
            // Sort the items in the list in ascending order.
            lstView.Sorting = SortOrder.Ascending;

            List<int> indexes = new List<int>();
            for(int i = 0; i < columns.Count; i++)
            {
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
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerListAdd trainerListAdd = new TrainerListAdd(this);
            AdminUI.Initialize_UserControl(trainerListAdd, Controls);
            trainerListAdd.BringToFront();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstViewTrainer.Items)
            {
                if (item.Checked || item.Selected)
                {
                    List<string> valuesList = new List<string>();
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        valuesList.Add(subItem.Text);
                    }

                    //Delete the dependencies of the trainer on multiple tables
                    string IdColumn = "TrainerId";
                    string IdValue = item.SubItems[0].Text;
                    List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.Search_Row_For_Value(IdColumn, IdValue);
                    foreach(Row row in classRowsByTrainerId)
                    {
                        Programming_Café_DB.classTable.Del_Row(row);
                    }

                    //Delete the trainer from the trainerTable and Database
                    Programming_Café_DB.trainerTable.Del_Row(valuesList);

                    //Update ListView
                    Load_Trainer_ListView();
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
