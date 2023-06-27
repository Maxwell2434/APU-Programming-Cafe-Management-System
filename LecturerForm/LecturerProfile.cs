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
    public partial class LecturerProfile : UserControl
    {
        Lecturer lecturer;
        public LecturerProfile(Lecturer lecturer)
        {
            InitializeComponent();
            this.lecturer = lecturer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Column columnToSearch = Programming_Café_DB.userTable.Username;
                int count = Programming_Café_DB.userTable.SearchRowForValue(columnToSearch, txtBoxUsername.Text).Count;
                if (count == 0 || lecturer.Username == txtBoxUsername.Text)
                {
                    lecturer.Username = txtBoxUsername.Text;
                    lecturer.Password = txtBoxPassword.Text;
                    lecturer.Name = txtBoxName.Text;
                    lecturer.Address = txtBoxAddress.Text;
                    lecturer.Phone = txtBoxPhone.Text;
                    lecturer.Email = txtBoxEmail.Text;
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Username Already Exists");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Save Failed");
            }

        }

        private void LecturerProfile_Load(object sender, EventArgs e)
        {
            txtBoxUsername.Text = lecturer.Username;
            txtBoxPassword.Text = lecturer.Password;
            txtBoxName.Text = lecturer.Name;
            txtBoxAddress.Text = lecturer.Address;
            txtBoxPhone.Text = lecturer.Phone;
            txtBoxEmail.Text = lecturer.Email;
        }
    }
}
