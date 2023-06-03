using APU_Programming_Café_Management_System.AdminForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            SetupListView();
        }

        public void SetupListView()
        {
            lstViewTrainer.Clear();
            // Set the view to show details.
            lstViewTrainer.View = View.Details;
            // Display check boxes.
            lstViewTrainer.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            lstViewTrainer.FullRowSelect = true;
            // Display grid lines.
            lstViewTrainer.GridLines = true;
            // Sort the items in the list in ascending order.
            lstViewTrainer.Sorting = SortOrder.Ascending;


            List<Collumn> collumns = Programming_Café_DB.trainerTable.Collumns;
            foreach (Collumn collumn in collumns)
            {
                lstViewTrainer.Columns.Add(collumn.Name);
            }

            List<Row> rows = Programming_Café_DB.trainerTable.Rows;
            foreach (Row row in rows)
            {
                string[] arr_value = row.Get_Value_Arr();

                lstViewTrainer.Items.Add(new ListViewItem(arr_value));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainerListAdd trainerListAdd = new TrainerListAdd(this);
            Initialize_UserControl(trainerListAdd);
            trainerListAdd.BringToFront();

        }

        private void Initialize_UserControl(UserControl userControl)
        {
            userControl.Show();
            Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstViewTrainer
        }
    }
}
