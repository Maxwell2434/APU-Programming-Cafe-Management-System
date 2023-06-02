using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace APU_Programming_Café_Management_System
{
    public class Table
    {
        //Test
        private List<Collumn> _collumns = new List<Collumn>();
        private List<Row> _rows = new List<Row>(); 
        private static int _collumnSeed = 0;

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


        public void Add_Collumn (Collumn collumn)
        {
            _collumns.Add(collumn);
        }

        public void Add_Rows (DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                _rows.Add(new Row(dr, _collumns));
            }
        }

        public Collumn Get_Collumn(string Name)
        {
            return (_collumns.Find(Collumn => Collumn.collumnName == Name));
        }

        public List<Row> Search_Row_For_Value(Collumn collumn, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in rows)
            {
                if (row.values[collumn] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }

        public List<Row> Search_Row_For_Value(string collumnName, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in rows)
            {
                if (row.values[Get_Collumn(collumnName)] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }





    }
}
