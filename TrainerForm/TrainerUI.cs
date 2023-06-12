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
    public partial class TrainerUI : Form
    {
        Trainer trainer;
        TrainerProfile trainerProfilePage;
        TrainerHome trainerHomePage;
        AdminFeedback adminFeedback;
        TrainerClasses trainerClasses;
        TrainerStudents trainerStudents;
        public TrainerUI(User user)
        {
            InitializeComponent();
            trainer = new Trainer(user);
            trainerHomePage = new TrainerHome(trainer);
            trainerProfilePage= new TrainerProfile(trainer);
            adminFeedback = new AdminFeedback(trainer);
            trainerClasses = new TrainerClasses(trainer);
            trainerStudents = new TrainerStudents(trainer);
        }

        private void TrainerUI_Load(object sender, EventArgs e)
        {
            Initialize_UserControl(trainerProfilePage, Controls);
            Initialize_UserControl(trainerHomePage, Controls);
            Initialize_UserControl(adminFeedback, Controls);
            Initialize_UserControl(trainerClasses, Controls);
            Initialize_UserControl(trainerStudents, Controls);
            trainerHomePage.BringToFront();
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            trainerProfilePage.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            trainerHomePage.BringToFront();
            trainerHomePage.Load_Label();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            adminFeedback.BringToFront();
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            trainerClasses.BringToFront();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            trainerStudents.BringToFront();
            trainerStudents.Load_List_View();
        }
    }
}
