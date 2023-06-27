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


        public Column Level
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

        public Column ScheduleDay
        {
            get { return Columns[4]; }
            set { Columns[4] = value; }
        }

        public Column StartHour
        {
            get { return Columns[5]; }
            set { Columns[5] = value; }
        }
        public Column EndHour
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
            AddColumn(new Column("Id"));
            AddColumn(new Column("ModuleId"));
            AddColumn(new Column("TrainerId"));
            AddColumn(new Column("Level"));
            AddColumn(new Column("ScheduleDay"));
            AddColumn(new Column("StartHour"));
            AddColumn(new Column("EndHour"));
            AddColumn(new Column("Fee"));
            AddColumn(new Column("Duration"));

            AddRows(dt);

        }
    }
}
