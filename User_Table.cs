﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class User_Table : Table
    {

        public Collumn Id
        {
            get { return collumns[0]; }
            set { collumns[0] = value; }
        }

        public Collumn Username
        {
            get { return collumns[1]; }
            set { collumns[1] = value; }
        }

        public Collumn Password
        {
            get { return collumns[2]; }
            set { collumns[2] = value; }
        }

        public Collumn Role
        {
            get { return collumns[3]; }
            set { collumns[3] = value; }
        }

        public User_Table(DataTable dt) 
        {
            Add_Collumn(new Collumn("Id"));
            Add_Collumn(new Collumn("Username"));
            Add_Collumn(new Collumn("Password")); 
            Add_Collumn(new Collumn("Role"));
            
            Add_Rows(dt);


        }

        public List<Row> Search_Row_For_Username_Value(string value)
        {
            return (Search_Row_For_Value(Username, value));
        }
    }
}
