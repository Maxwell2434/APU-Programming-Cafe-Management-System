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
            administrator.Username= txtBoxUsername.Text;
            administrator.Password= txtBoxPassword.Text;
            administrator.Name= txtBoxName.Text;
            administrator.Address= txtBoxAddress.Text;
            administrator.Phone= txtBoxPhone.Text;
            administrator.Email= txtBoxEmail.Text;
            //programming_Café_Database.Update_Table_Database(new Table(programming_Café_Database.adminTable.TableName, programming_Café_Database.adminTable.))
                
        }
    }
}
