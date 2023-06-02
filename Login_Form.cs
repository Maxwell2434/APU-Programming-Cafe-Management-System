using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace APU_Programming_Café_Management_System
{
    public partial class Login_Form : Form
    {
        string connectionString;
        Programming_Café_DB Programming_Café_Database;
        public Login_Form()
        {
            InitializeComponent();
            Programming_Café_Database = new Programming_Café_DB();
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            User user = new User(txtbox_Username.Text, txtbox_Password.Text);
            if(user.login_Attempt(Programming_Café_Database) == true)
            {
                if(user.role.isAdministrator == true)
                {
                    this.Hide();
                    AdminHomePage adminHomePage = new AdminHomePage(Programming_Café_Database, user.Id);
                    adminHomePage.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
