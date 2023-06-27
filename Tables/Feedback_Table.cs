using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class Feedback_Table : Table
    {
        public Column Id
        {
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column TrainerId
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column AdministratorId
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }



        public Column Feedback
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }


        public Feedback_Table(DataTable dt)
        {
            TableName = dt.TableName;
            AddColumn(new Column("Id"));
            AddColumn(new Column("TrainerId"));
            AddColumn(new Column("AdministratorId"));
            AddColumn(new Column("Feedback"));

            AddRows(dt);
        }
    }
}
