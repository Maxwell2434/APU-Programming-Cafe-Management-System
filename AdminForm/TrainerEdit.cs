using APU_Programming_Café_Management_System.Tables;
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

namespace APU_Programming_Café_Management_System.AdminForm
{
    public partial class TrainerEdit : UserControl
    {
        string trainerId;
        public TrainerEdit(string trainerId)
        {
            InitializeComponent();
            this.trainerId = trainerId;
            Load_ListView();
            string trainerName = Programming_Café_DB.trainerTable.Get_ColumnValue_From_Row(Programming_Café_DB.trainerTable.Id, trainerId, Programming_Café_DB.trainerTable.Name);
            lblTitle.Text = "Modules Handled by " + trainerName;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

            Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
            List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.Search_Row_For_Value(columnToSearch, trainerId);

            //Delete the class and its related dependencies based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {

                Programming_Café_DB.classTable.Del_Row(classRowsByTrainerId[itemIndexes[i]]);
                //Update ListView
                Load_ListView();
            }

                    
    
            
        }

        public void Load_ListView()
        {
            lstViewTrainer.Items.Clear();
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch = ClassTable.TrainerId;

            List<Row> rows = ClassTable.Search_Row_For_Value(columnToSearch, trainerId);

            List<Column> newColumns = new List<Column>
            {
                Programming_Café_DB.moduleTable.Name,
                Programming_Café_DB.classTable.Level
            };


            columnToSearch = Programming_Café_DB.moduleTable.Id;
            Column columnToReturn = Programming_Café_DB.moduleTable.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i< rows.Count; i++)
            {
                string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, rows[i].values[Programming_Café_DB.classTable.ModuleId], columnToReturn);
                string Level = rows[i].values[Programming_Café_DB.classTable.Level];
                List<string> arr_values = new List<string>
                {
                    ModuleName,
                    Level
                };
                
                newRows.Add(new Row ("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Name",
                "Level",
            };

            AdminUI.SetupListView(lstViewTrainer, newColumns, newRows, columnsToInclude);

            

  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerEditAdd trainerEditAdd = new TrainerEditAdd(this, trainerId);
            AdminUI.Initialize_UserControl(trainerEditAdd, Controls);
            trainerEditAdd.BringToFront();

        }

        private void TrainerEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
