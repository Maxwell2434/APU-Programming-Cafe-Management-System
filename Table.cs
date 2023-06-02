using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    internal class Table
    {
        //Test
        private List<Collumn> _collumns = new List<Collumn>();
        private List<Row> _rows = new List<Row>(); 

        public List<Collumn> collumns 
        {
            get { return _collumns; }
            set { _collumns = value; }
        }
        public List<Row> rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public void Add_Collumn (string collumn_Name)
        {
            _collumns.Add(new Collumn(collumn_Name));
        }

        public void Add_Rows (DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                _rows.Add(new Row(dt));
            }
        }

    

        public int Get_Count_of_Rows_Matching_Value (Programming_Café_DB Programming_Café_Database, string Name, string value)
        {
            return(Programming_Café_Database.studentTable2.collumns.Find(column => column.collumnName == Name).Search_RowIndex_For_Value(value).Count());

        }

    }
}
