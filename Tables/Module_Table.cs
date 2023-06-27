using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Tables
{
    public class Module_Table : Table
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

        

        public Module_Table(DataTable dt)
        {
            TableName = dt.TableName;
            AddColumn(new Column("Id"));
            AddColumn(new Column("Name"));

            AddRows(dt);


        }
    }
}
