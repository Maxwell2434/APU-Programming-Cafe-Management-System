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
        private Administrator _administrator;
        private Programming_Café_DB programming_Café_Database;
        public AdminProfile()
        {
            InitializeComponent();
        }

        public Administrator administrator
        {
            get { return _administrator; }
            set { _administrator = value; }
        }

        public Programming_Café_DB Programming_Café_Database
        {
            get { return programming_Café_Database; }
            set { programming_Café_Database = value; }
        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {
            txtBoxName.Text = administrator.Name;
            txtBoxAddress.Text = administrator.Address;
            txtBoxPhone.Text = administrator.Phone;
            txtBoxEmail.Text = administrator.Email;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _administrator.Name= txtBoxName.Text;
            _administrator.Address= txtBoxAddress.Text;
            _administrator.Phone= txtBoxPhone.Text;
            _administrator.Email= txtBoxEmail.Text;
            //programming_Café_Database.Update_Table_Database(new Table(programming_Café_Database.adminTable.TableName, programming_Café_Database.adminTable.))
                
        }
    }
}
