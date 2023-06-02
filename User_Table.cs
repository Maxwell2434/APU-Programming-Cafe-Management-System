using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class User_Table : Table
    {

        public Collumn Id
        {
            get { return Collumns[0]; }
            set { Collumns[0] = value; }
        }

        public Collumn Username
        {
            get { return Collumns[1]; }
            set { Collumns[1] = value; }
        }

        public Collumn Password
        {
            get { return Collumns[2]; }
            set { Collumns[2] = value; }
        }

        public Collumn Role
        {
            get { return Collumns[3]; }
            set { Collumns[3] = value; }
        }

        public User_Table(DataTable dt) 
        {
            Add_Collumn(new Collumn("Id"));
            Add_Collumn(new Collumn("Username"));
            Add_Collumn(new Collumn("Password")); 
            Add_Collumn(new Collumn("Role"));
            
            Add_Rows(dt);


        }

        public List<Row> Search_Row_For_Username_Value(string value)
        {
            return (Search_Row_For_Value(Username, value));
        }
    }
}
