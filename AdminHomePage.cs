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
    public partial class AdminHomePage : Form
    {
        public AdminHomePage(Programming_Café_DB programming_Café_DB, string UserId)
        {
            InitializeComponent();
            Administrator administrator = new Administrator(programming_Café_DB.adminTable, UserId);
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

        }
    }
}
