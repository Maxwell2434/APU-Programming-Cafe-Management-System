using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace APU_Programming_Café_Management_System
{
    public class Column
    {
        //FIELDS
        private string name;
        private bool isPKey;

        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsPKey
        {
            get { return isPKey; }
            set { isPKey = value; }  
        }


        //CONSTRUCTOR
        public Column(string name) 
        { 
            this.name = name;
            if(name == "Id")
            {
                this.isPKey = true;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Column otherColumn = (Column)obj;
            return name == otherColumn.name && isPKey == otherColumn.isPKey;
        }




    }
}
