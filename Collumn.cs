using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    internal class Collumn : Table
    {
        //FIELDS
        private string _collumnName;
        private int _collumnIndex;
        private static int collumnSeed = 0;

        //PROPERTIES
        public string collumnName
        {
            get { return _collumnName; }
            set { _collumnName = value; }
        }

        public int collumnIndex
        {
            get { return _collumnIndex; }
            set { _collumnIndex = value; }
        }

        //CONSTRUCTOR
        public Collumn(string name) 
        { 
            _collumnName = name; 
            _collumnIndex = collumnSeed; 
            collumnSeed++; 
        }

        //METHODS
        public int[] Search_RowIndex_For_Value(string value)
        {
            int[] result = new int[0];
            foreach(Row row in rows)
            {
                if (row.values[collumnIndex] == value)
                {
                    result.Append(row.rowIndex);
                }
            }
            return result;
        }


    }
}
