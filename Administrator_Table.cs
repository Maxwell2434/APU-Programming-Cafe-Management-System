using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Administrator_Table : Table
    {
        public Collumn Id
        {
            get { return collumns[0]; }
            set { collumns[0] = value; }
        }

        public Collumn Name
        {
            get { return collumns[1]; }
            set { collumns[1] = value; }
        }

        public Collumn Address
        {
            get { return collumns[2]; }
            set { collumns[2] = value; }
        }

        public Collumn Phone
        {
            get { return collumns[3]; }
            set { collumns[3] = value; }
        }

        public Collumn Email
        {
            get { return collumns[4]; }
            set { collumns[4] = value;}
        }

        public Collumn UserId
        {
            get { return collumns[5]; }
            set { collumns[5] = value;}
        }

        public Administrator_Table(DataTable dt)
        {
            Add_Collumn(new Collumn("Id"));
            Add_Collumn(new Collumn("Name"));
            Add_Collumn(new Collumn("Address"));
            Add_Collumn(new Collumn("Phone"));
            Add_Collumn(new Collumn("Email"));
            Add_Collumn(new Collumn("UserId"));

            Add_Rows(dt);


        }

    
    }
}
