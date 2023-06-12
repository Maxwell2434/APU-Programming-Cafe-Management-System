using APU_Programming_Café_Management_System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Row
    {
        //FIELDS
        private Dictionary<Column, string> _values;
        private string tableName;
        //PROPERTIES
        public Dictionary<Column, string> values
        {
            get { return _values; }
            set { Programming_Café_DB.Update_Table_Database(tableName, this, value); _values = value; }
        }


        //CONSTRUCTOR
        public Row(DataRow dr, List<Column> collumns)
        {
            tableName = dr.Table.TableName;
            _values = new Dictionary<Column, string>();
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                _values.Add(collumns[i], dr[i].ToString());
            }
        }

        public Row(string tableName, List<Column> collumns, List<string> arr_Values)
        {
            this.tableName = tableName;
            _values = new Dictionary<Column, string>();
            for (int i = 0; i < arr_Values.Count; i++)
            {
                _values.Add(collumns[i], arr_Values[i]);
            }
        }

        public Row(string tableName, Dictionary<Column, string> values)
        {
            this.tableName = tableName;
            this.values = values;
        }


        public string[] Get_Value_Arr()
        {
            string[] arr_values = new string[0];
            foreach (KeyValuePair<Column, string> kvp in values)
            {
                arr_values = arr_values.Append(kvp.Value).ToArray();
            }
            return arr_values;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Row otherRow = (Row)obj;

            // Compare the values dictionary
            return values.SequenceEqual(otherRow.values);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var kvp in values)
                {
                    hash = hash * 23 + kvp.Key.GetHashCode();
                    hash = hash * 23 + kvp.Value?.GetHashCode() ?? 0;
                }
                return hash;
            }
        }
    }
}
