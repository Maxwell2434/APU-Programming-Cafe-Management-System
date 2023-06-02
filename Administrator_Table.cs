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
            get { return Collumns[0]; }
            set { Collumns[0] = value; }
        }

        public Collumn Name
        {
            get { return Collumns[1]; }
            set { Collumns[1] = value; }
        }

        public Collumn Address
        {
            get { return Collumns[2]; }
            set { Collumns[2] = value; }
        }

        public Collumn Phone
        {
            get { return Collumns[3]; }
            set { Collumns[3] = value; }
        }

        public Collumn Email
        {
            get { return Collumns[4]; }
            set { Collumns[4] = value;}
        }

        public Collumn UserId
        {
            get { return Collumns[5]; }
            set { Collumns[5] = value;}
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
