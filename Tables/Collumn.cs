using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace APU_Programming_Café_Management_System
{
    public class Collumn
    {
        //FIELDS
        private string name;
        private bool isKey;
        private string[] _values;

        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsKey
        {
            get { return isKey; }
            set { isKey = value; }  
        }

        public string[] values
        {
            get { return _values; }
            set { _values = value; }
        }

        //CONSTRUCTOR
        public Collumn(string name) 
        { 
            this.name = name;
            if(name == "Id")
            {
                this.isKey = true;
            }
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
