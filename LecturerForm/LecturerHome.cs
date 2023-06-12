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

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerHome : UserControl
    {
        Lecturer lecturer;
        public LecturerHome(Lecturer lecturer)
        {
            InitializeComponent();
            this.lecturer = lecturer;
        }

        private void LecturerHome_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + lecturer.Name;
        }
    }
}
