using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class Lecturer_Table : Table
    {
        public Column Id
        {
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column Name
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column Address
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }

        public Column Phone
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

        public Column Email
        {
            get { return Columns[4]; }
            set { Columns[4] = value; }
        }

        public Column UserId
        {
            get { return Columns[5]; }
            set { Columns[5] = value; }
        }

        public Lecturer_Table(DataTable dt)
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
