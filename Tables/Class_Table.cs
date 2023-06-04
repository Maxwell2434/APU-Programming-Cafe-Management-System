using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class Class_Table : Table
    {
        public Column Id
        {
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column ModuleId
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column TrainerId
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }

  

        public Column ScheduleDay
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

        public Column StartHour
        {
            get { return Columns[4]; }
            set { Columns[4] = value; }
        }

        public Column EndHour
        {
            get { return Columns[5]; }
            set { Columns[5] = value; }
        }
        public Column Level
        {
            get { return Columns[6]; }
            set { Columns[6] = value;}
        }

        public Column Fee
        {
            get { return Columns[7]; }
            set { Columns[7] = value;}
        }

        public Column Duration
        {
            get { return Columns[8]; }
            set { Columns[8] = value; }
        }
        public Class_Table(DataTable dt) 
        {
            TableName = dt.TableName;
            Add_Collumn(new Column("Id"));
            Add_Collumn(new Column("ModuleId"));
            Add_Collumn(new Column("TrainerId"));
            Add_Collumn(new Column("ScheduleDay"));
            Add_Collumn(new Column("StartHour"));
            Add_Collumn(new Column("EndHour"));
            Add_Collumn(new Column("Level"));
            Add_Collumn(new Column("Fee"));
            Add_Collumn(new Column("Duration"));

            Add_Rows(dt);

        }
    }
}
