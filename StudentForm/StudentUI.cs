using APU_Programming_Café_Management_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.StudentForm
{
    public partial class StudentUI : Form
    {
        Student student;
        StudentHome studentHome;
        StudentInvoice studentInvoice;
        StudentSchedule studentSchedule;
        StudentRequests studentRequests;
        StudentProfile studentProfile;
        public StudentUI(User user)
        {
            InitializeComponent();
            this.student = new Student(user);
            this.studentHome = new StudentHome(student);
            this.studentInvoice = new StudentInvoice(student);
            this.studentSchedule = new StudentSchedule(student);
            this.studentRequests = new StudentRequests(student);
            this.studentProfile = new StudentProfile(student);
        }
        private void StudentUI_Load(object sender, EventArgs e)
        {
            Initialize_UserControl(studentHome, Controls);
            Initialize_UserControl(studentInvoice, Controls);
            Initialize_UserControl(studentSchedule, Controls);
            Initialize_UserControl(studentRequests, Controls);
            Initialize_UserControl(studentProfile, Controls);
            studentHome.BringToFront();
        }
        public static void Initialize_UserControl(UserControl userControl, Control.ControlCollection controls)
        {
            userControl.Show();
            controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            studentInvoice.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            studentProfile.BringToFront();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            studentSchedule.BringToFront();
            studentSchedule.Load_List_View();
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            studentRequests.BringToFront();
            studentRequests.Load_List_View();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            studentHome.Load_Label();
            studentHome.BringToFront();
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
