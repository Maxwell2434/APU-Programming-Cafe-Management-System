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

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            TrainerEditAdd trainerEditAdd = new TrainerEditAdd(lstViewTrainer.SelectedItems[0].SubItems[0].Text);
            AdminUI.Initialize_UserControl(trainerEditAdd, Controls);
            trainerEditAdd.BringToFront();
        }

        private void Load_ListView()
        {
            lstViewTrainer.Items.Clear();
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch = ClassTable.TrainerId;

            List<Row> rows = ClassTable.Search_Row_For_Value(columnToSearch, trainerId);

            List<Column> newColumns = new List<Column>
            {
                Programming_Café_DB.module_Table.Name,
                Programming_Café_DB.classTable.Level
            };


            columnToSearch = Programming_Café_DB.module_Table.Id;
            Column columnToReturn = Programming_Café_DB.module_Table.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i< rows.Count; i++)
            {
                string ModuleName = Programming_Café_DB.module_Table.Get_ColumnValue_From_Row(columnToSearch, rows[i].values[Programming_Café_DB.classTable.ModuleId], columnToReturn);
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

            TrainerList.SetupListView(lstViewTrainer, newColumns, newRows, columnsToInclude);

            

  
        }
    }
}
