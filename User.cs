using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    internal class User
    {
        private string _username; 
        private string _password;
        private Role _role;
        public User(string Username, string Password) 
        {
            _username = Username;
            _password = Password;
            _role = new Role();
        }

        public string Username
        {
            get{ return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Role role
        { 
            get { return _role; }
            set { _role = value; }
        }

        public bool login_Attempt(Programming_Café_DB Programming_Café_Database)
        {
            DataRow[] dataRows = Programming_Café_DB.Get_DataRows_From_DataTable(Programming_Café_Database.userTable, "Username", _username);
            if (dataRows.Length == 1 )
            {
                if (dataRows[0]["Password"].ToString() == _password)
                {
                    
                    int p_Key = Convert.ToInt32(dataRows[0]["Id"].ToString());
                    Check_User_Role(Programming_Café_Database, p_Key);
                    return true;
                }

                else { MessageBox.Show("Password is Wrong"); }
            }
            else
            {
                MessageBox.Show("Username doesn't exist");
            }
            return true;
        }

        public void Check_User_Role(Programming_Café_DB Programming_Café_Database, int p_Key)
        {
            
            DataRow[] dataRows = Programming_Café_DB.Get_DataRows_From_DataTable(Programming_Café_Database.studentTable, "UserId", p_Key);
            if (dataRows.Length == 1)
            {
                _role.isStudent = true;
            }

        }
    }
}
