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
        //Properties
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
            set { Columns[4] = value;}
        }

        public Column UserId
        {
            get { return Columns[5]; }
            set { Columns[5] = value;}
        }

        //Constructor
        public Administrator_Table(DataTable dt)
        {
            TableName = dt.TableName;
            AddColumn(new Column("Id"));
            AddColumn(new Column("Name"));
            AddColumn(new Column("Address"));
            AddColumn(new Column("Phone"));
            AddColumn(new Column("Email"));
            AddColumn(new Column("UserId"));

            AddRows(dt);


        }

    
    }
}
