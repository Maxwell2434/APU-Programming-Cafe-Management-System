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
            Load_Label();
        }
        public void Load_Label()
        {
            Column columnToSearch = Programming_Café_DB.lecturerTable.Id;
            Column columnToReturn = Programming_Café_DB.lecturerTable.Name;
            lecturer.Name = Programming_Café_DB.lecturerTable.Get_ColumnValue_From_Row(columnToSearch, lecturer.Id, columnToReturn);
            lblWelcome.Text = "Welcome, " + lecturer.Name;
        }

    }
}
