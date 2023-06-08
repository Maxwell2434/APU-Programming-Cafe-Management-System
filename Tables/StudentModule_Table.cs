using APU_Programming_Café_Management_System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class StudentModule_Table : Table
    {
        public Column StudentId
        {
            get { return Columns[0]; }
            set { Columns[0] = value; }
        }

        public Column ModuleId
        {
            get { return Columns[1]; }
            set { Columns[1] = value; }
        }

        public Column Level
        {
            get { return Columns[2]; }
            set { Columns[2] = value; }
        }

        public Column ClassId
        {
            get { return Columns[3]; }
            set { Columns[3] = value; }
        }

        public Column PaymentStatus
        {
            get { return Columns[4]; }
            set { Columns[4] = value; }
        }

        public Column EnrollmentMonth
        {
            get { return Columns[5]; }
            set { Columns[5] = value;}
        }

        public StudentModule_Table(DataTable dt)
        {
            TableName = dt.TableName;
            Add_Collumn(new Column("StudentId"));
            Add_Collumn(new Column("ModuleId"));
            Add_Collumn(new Column("Level"));
            Add_Collumn(new Column("ClassId"));
            Add_Collumn(new Column("PaymentStatus"));
            Add_Collumn(new Column("EnrollmentMonth"));


            Add_Rows(dt);

        }
    }
}
