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
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column Username
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column Password
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
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
