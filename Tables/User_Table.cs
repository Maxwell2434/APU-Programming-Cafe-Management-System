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

        public Column Id
        {
            get { return Collumns[0]; }
            set { Collumns[0] = value; }
        }

        public Column Username
        {
            get { return Collumns[1]; }
            set { Collumns[1] = value; }
        }

        public Column Password
        {
            get { return Collumns[2]; }
            set { Collumns[2] = value; }
        }


        public User_Table(DataTable dt) 
        {
            TableName = dt.TableName;
            Add_Collumn(new Column("Id"));
            Add_Collumn(new Column("Username"));
            Add_Collumn(new Column("Password")); 
            
            Add_Rows(dt);

        }


        public List<Row> Search_Row_For_Username_Value(string value)
        {
            return (Search_Row_For_Value(Username, value));
        }
    }
}
