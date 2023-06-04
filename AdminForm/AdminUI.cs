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
        AdminHome adminHome = new AdminHome();
        AdminProfile adminProfilePage;
        TrainerList trainerList = new TrainerList();



        public AdminUI(User user)
        {
            InitializeComponent();
            administrator = new Administrator(user);
            adminProfilePage = new AdminProfile(administrator);
        }

        private void AdminUI_Load(object sender, EventArgs e)
        {
            Initialize_UserControl(adminHome, Controls);
            Initialize_UserControl(adminProfilePage, Controls);
            Initialize_UserControl(trainerList, Controls);
        }



        private void btnProfile_Click(object sender, EventArgs e)
        {
            adminProfilePage.BringToFront();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            trainerList.Show();
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

        
    }
}
