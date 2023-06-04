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

namespace APU_Programming_Café_Management_System
{
    public partial class AdminUI : Form
    {
        private Administrator administrator;
        AdminHome adminHome;
        AdminProfile adminProfilePage;
        TrainerList trainerList = new TrainerList();
        TrainerFeedback trainerFeedback;



        public AdminUI(User user)
        {
            InitializeComponent();
            administrator = new Administrator(user);
            adminHome = new AdminHome(administrator);
            adminProfilePage = new AdminProfile(administrator);
            trainerFeedback= new TrainerFeedback(administrator);
        }

        private void AdminUI_Load(object sender, EventArgs e)
        {
            Initialize_UserControl(adminHome, Controls);
            Initialize_UserControl(adminProfilePage, Controls);
            Initialize_UserControl(trainerList, Controls);
            Initialize_UserControl(trainerFeedback, Controls);
            adminHome.BringToFront();
        }



        private void btnProfile_Click(object sender, EventArgs e)
        {
            adminProfilePage.BringToFront();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            trainerList.BringToFront();
        }

        public static void Initialize_UserControl(UserControl userControl, Control.ControlCollection controls)
        {
            userControl.Show();
            controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            adminHome.BringToFront();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form loginForm = new Login_Form();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            trainerFeedback.BringToFront();
            trainerFeedback.Load_ListView();

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
            for (int i = 0; i < columns.Count; i++)
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
    }
}
