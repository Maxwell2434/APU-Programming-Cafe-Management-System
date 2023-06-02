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
            List<Row> rows = Programming_Café_Database.userTable.Search_Row_For_Username_Value(_username);
            if (rows.Count == 1)
            {
                if (rows[0].values["Password"] == _password)
                {
                    
                    string p_Key = rows[0].values["Id"];
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

        public void Check_User_Role(Programming_Café_DB Programming_Café_Database, string p_Key)
        {
            List<Row> rows = Programming_Café_Database.studentTable.Get_Rows_Matching_Value(p_Key);
            if (rows.Count == 1)
            {
                _role.isStudent = true;
            }

        }
    }
}
