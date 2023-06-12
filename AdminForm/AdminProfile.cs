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
    public partial class AdminProfile : UserControl
    {
        private Administrator administrator;
        public AdminProfile(Administrator administrator)
        {
            InitializeComponent();
            this.administrator = administrator;
        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {
            txtBoxUsername.Text = administrator.Username;
            txtBoxPassword.Text = administrator.Password;
            txtBoxName.Text = administrator.Name;
            txtBoxAddress.Text = administrator.Address;
            txtBoxPhone.Text = administrator.Phone;
            txtBoxEmail.Text = administrator.Email;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Column columnToSearch = Programming_Café_DB.userTable.Username;
                int count = Programming_Café_DB.userTable.Search_Row_For_Value(columnToSearch, txtBoxUsername.Text).Count;
                if(count == 0 || administrator.Username == txtBoxUsername.Text)
                {
                    administrator.Username = txtBoxUsername.Text;
                    administrator.Password = txtBoxPassword.Text;
                    administrator.Name = txtBoxName.Text;
                    administrator.Address = txtBoxAddress.Text;
                    administrator.Phone = txtBoxPhone.Text;
                    administrator.Email = txtBoxEmail.Text;
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
    }
}
