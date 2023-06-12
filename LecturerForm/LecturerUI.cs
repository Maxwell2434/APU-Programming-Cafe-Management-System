using APU_Programming_Café_Management_System.Users;
using System;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerUI : Form
    {
        Lecturer lecturer;
        LecturerHome lecturerHome;
        LecturerStudents lecturerStudents;
        LecturerProfile lecturerProfile;
        public LecturerUI(User user)
        {
            InitializeComponent();
            lecturer = new Lecturer(user);
            lecturerHome = new LecturerHome(lecturer);
            lecturerStudents = new LecturerStudents();
            lecturerProfile = new LecturerProfile(lecturer);
        }



        private void LecturerUI_Load(object sender, EventArgs e)
        {
            Initialize_UserControl(lecturerHome, Controls);
            Initialize_UserControl(lecturerStudents, Controls);
            Initialize_UserControl(lecturerProfile, Controls);
        }

        public static void Initialize_UserControl(UserControl userControl, Control.ControlCollection controls)
        {
            userControl.Show();
            controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form loginForm = new Login_Form();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lecturerHome.BringToFront();
            lecturerHome.Load_Label();
        }


        private void btnStudents_Click(object sender, EventArgs e)
        {
            lecturerStudents.BringToFront();
            lecturerStudents.Load_List_View();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lecturerProfile.BringToFront();
        }
    }
}
