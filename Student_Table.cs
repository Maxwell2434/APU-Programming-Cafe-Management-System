using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace APU_Programming_Café_Management_System
{
    internal class Student_Table : Table
    {
        private int[] Id;

        public Student_Table(DataTable dt)
        {
            Add_Collumn("Id");
            Add_Collumn("Name");
            Add_Collumn("TP_Number");
            Add_Collumn("Address");
            Add_Collumn("Phone");
            Add_Collumn("Email");

            Add_Rows(dt);
            
        }
    }
}
