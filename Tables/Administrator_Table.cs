using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Administrator_Table : Table
    {
        public Column Id
        {
            get { return Collumns[0]; }
            set { Collumns[0] = value; }
        }

        public Column Name
        {
            get { return Collumns[1]; }
            set { Collumns[1] = value; }
        }

        public Column Address
        {
            get { return Collumns[2]; }
            set { Collumns[2] = value; }
        }

        public Column Phone
        {
            get { return Collumns[3]; }
            set { Collumns[3] = value; }
        }

        public Column Email
        {
            get { return Collumns[4]; }
            set { Collumns[4] = value;}
        }

        public Column UserId
        {
            get { return Collumns[5]; }
            set { Collumns[5] = value;}
        }

        public Administrator_Table(DataTable dt)
        {
            TableName = dt.TableName;
            Add_Collumn(new Column("Id"));
            Add_Collumn(new Column("Name"));
            Add_Collumn(new Column("Address"));
            Add_Collumn(new Column("Phone"));
            Add_Collumn(new Column("Email"));
            Add_Collumn(new Column("UserId"));

            Add_Rows(dt);


        }

    
    }
}
