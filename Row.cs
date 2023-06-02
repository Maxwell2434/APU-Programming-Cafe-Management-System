using APU_Programming_Café_Management_System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Row
    {
        //FIELDS
        private Dictionary<Collumn, string> _values;

        //PROPERTIES
        public Dictionary<Collumn, string> values
        {
            get { return _values; }
            set { _values = value; }
        }


        //CONSTRUCTOR
        public Row(DataRow dr, List<Collumn> collumns) 
        {
            _values = new Dictionary<Collumn, string>();
            for (int i = 0; i< dr.ItemArray.Length; i++)
            {
                _values.Add(collumns[i], dr[i].ToString());
            }

        }
    }
}
