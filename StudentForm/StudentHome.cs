using APU_Programming_Café_Management_System.LecturerForm;
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
    public partial class StudentHome : UserControl
    {
        Student student;
        public StudentHome(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void StudentHome_Load(object sender, EventArgs e)
        {
            Load_Label();
        }
        public void Load_Label()
        {
            Column columnToSearch = Programming_Café_DB.studentTable.Id;
            Column columnToReturn = Programming_Café_DB.studentTable.Name;
            student.Name = Programming_Café_DB.studentTable.GetColumnValueFromRow(columnToSearch, student.Id, columnToReturn);
            lblWelcome.Text = "Welcome, " + student.Name;
        }
    }
}
