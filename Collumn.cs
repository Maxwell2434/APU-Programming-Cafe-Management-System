using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace APU_Programming_Café_Management_System
{
    internal class Collumn
    {
        //FIELDS
        private string _collumnName;
        private string[] _values;

        //PROPERTIES
        public string collumnName
        {
            get { return _collumnName; }
            set { _collumnName = value; }
        }



        public string[] values
        {
            get { return _values; }
            set { _values = value; }
        }

        //CONSTRUCTOR
        public Collumn(string name) 
        { 
            _collumnName = name;
        }

        //METHODS

 


        /*
        public List<Row> Get_Rows_Matching_Value(string value)
        {
            Collumn coluumn = Get_Collumn(Name);
            List<Row> result = coluumn.Search_Row_For_Value(rows, value);
            return (Get_Collumn(Name).Search_Row_For_Value(rows, value));
        }
        */




    }
}
