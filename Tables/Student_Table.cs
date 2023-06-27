using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace APU_Programming_Café_Management_System
{
    public class Student_Table : Table
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

        public Column TP_Number
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }

        public Column Address
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

        public Column Phone
        {
            get { return Columns[4]; }
            set { Columns[4] = value; }
        }

        public Column Email
        {
            get { return Columns[5]; }
            set { Columns[5] = value; }
        }

        public Column UserId
        {
            get { return Columns[6]; }
            set { Columns[6] = value;}
        }

        public Student_Table(DataTable dt)
        {

            TableName = dt.TableName;
            AddColumn(new Column("Id"));
            AddColumn(new Column("Name"));
            AddColumn(new Column("TP_Number"));
            AddColumn(new Column("Address"));
            AddColumn(new Column("Phone"));
            AddColumn(new Column("Email"));
            AddColumn(new Column("UserId"));

            AddRows(dt);
            
        }


    }
}
