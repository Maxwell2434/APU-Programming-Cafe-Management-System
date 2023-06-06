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
    public partial class TrainerClasses : UserControl
    {
        Trainer trainer;
        public TrainerClasses(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void TrainerClasses_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Classes Handled by " + trainer.Name;
            Load_Classes_ListView();
        }

        public void Load_Classes_ListView()
        {
            lstViewTrainer.Items.Clear();
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch = ClassTable.TrainerId;

            List<Row> rows = ClassTable.Search_Row_For_Value(columnToSearch, trainer.Id);

            List<Column> newColumns = new List<Column>
            {
                new Column("Module"),
                ClassTable.Level,
                ClassTable.ScheduleDay,
                ClassTable.StartHour,
                ClassTable.EndHour,
                ClassTable.Fee
            };


            columnToSearch = Programming_Café_DB.moduleTable.Id;
            Column columnToReturn = Programming_Café_DB.moduleTable.Name;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, rows[i].values[ClassTable.ModuleId], columnToReturn);
                string ScheduleDay = rows[i].values[ClassTable.ScheduleDay];
                string StartHour = rows[i].values[ClassTable.StartHour];
                string EndHour = rows[i].values[ClassTable.EndHour];
                string Level = rows[i].values[ClassTable.Level];
                string Fee = rows[i].values[ClassTable.Fee];
                List<string> arr_values = new List<string>
                {
                    ModuleName,
                    Level,
                    ScheduleDay,
                    StartHour,
                    EndHour,
                    Fee
                };

                newRows.Add(new Row("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Module",
                "Level",
                "ScheduleDay",
                "StartHour",
                "EndHour",
                "Fee"
            };

            AdminUI.SetupListView(lstViewTrainer, newColumns, newRows, columnsToInclude);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerClassesAdd trainerClassesAdd = new TrainerClassesAdd(this);
            AdminUI.Initialize_UserControl(trainerClassesAdd, Controls);
            trainerClassesAdd.BringToFront();
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
            
            Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
            List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.Search_Row_For_Value(columnToSearch, trainer.Id);

            //Delete the class and its related dependencies based on the item indexes of the ListView
            //Deletes starting backwards to avoid troubles with indexing
            for (int i = itemIndexes.Count - 1; i >= 0; i--)
            {

                Programming_Café_DB.classTable.Del_Row(classRowsByTrainerId[itemIndexes[i]]);
                //Update ListView
                Load_Classes_ListView();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstViewTrainer.CheckedItems.Count == 1)
            {
                Column columnToSearch = Programming_Café_DB.classTable.TrainerId;
                List<Row> classRowsByTrainerId = Programming_Café_DB.classTable.Search_Row_For_Value(columnToSearch, trainer.Id);
                int index = lstViewTrainer.CheckedItems[0].Index;
                

                TrainerClassesUpdate trainerClassesUpdate = new TrainerClassesUpdate(this, trainer, classRowsByTrainerId[index]);
                AdminUI.Initialize_UserControl(trainerClassesUpdate, Controls);
                trainerClassesUpdate.BringToFront();
            }
            else
            {
                MessageBox.Show("Please Select a Class");
            }

            
        }

  
    }
}
