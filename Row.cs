using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    internal class Row : Table
    {
        //FIELDS
        private List<string> _values;
        private int _rowIndex;
        private static int _rowSeed=0;

        //PROPERTIES
        public List<string> values
        {
            get { return _values; }
            set { _values = value; }
        }

        public int rowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        //CONSTRUCTOR
        public Row(DataTable dt) 
        {
            _rowIndex = _rowSeed;
            _rowSeed++;
            values = new List<string>();
            for (int i = 0; i< dt.Rows[_rowIndex].ItemArray.Length; i++)
            {
                values.Add(dt.Rows[_rowIndex][i].ToString());
            }

        }
    }
}
