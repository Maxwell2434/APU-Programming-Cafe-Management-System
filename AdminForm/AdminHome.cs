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
    public partial class AdminHome : UserControl
    {
        Administrator administrator;
        public AdminHome(Administrator administrator)
        {
            InitializeComponent();
            this.administrator= administrator;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            Load_Label();
        }

        public void Load_Label()
        {
            Column columnToSearch = Programming_Café_DB.administratorTable.Id;
            Column columnToReturn = Programming_Café_DB.administratorTable.Name;
            administrator.Name = Programming_Café_DB.administratorTable.GetColumnValueFromRow(columnToSearch, administrator.Id, columnToReturn);
            lblWelcome.Text = "Welcome, " + administrator.Name;
        }
    }
}
