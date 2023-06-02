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
        private string tableName;
        //PROPERTIES
        public Dictionary<Collumn, string> values
        {
            get { return _values; }
            set { _values = value; Programming_Café_DB.Update_Table_Database(tableName, this, value); }
        }


        //CONSTRUCTOR
        public Row(DataRow dr, List<Collumn> collumns) 
        {
            tableName = dr.Table.TableName;
            _values = new Dictionary<Collumn, string>();
            for (int i = 0; i< dr.ItemArray.Length; i++)
            {
                _values.Add(collumns[i], dr[i].ToString());
            }

        }
    }
}
