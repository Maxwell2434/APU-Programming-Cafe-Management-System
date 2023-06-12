using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class Request_Table : Table
    {
        public Column Id
        {
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column StudentId
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column ModuleId
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }

        public Column Level
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

  
        public Request_Table(DataTable dt)
        {
            TableName = dt.TableName;
            Add_Collumn(new Column("Id"));
            Add_Collumn(new Column("StudentId"));
            Add_Collumn(new Column("ModuleId"));
            Add_Collumn(new Column("Level"));


            Add_Rows(dt);

        }
    }
}
