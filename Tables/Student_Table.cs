using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace APU_Programming_Café_Management_System
{
    public class Student_Table : Table
    {
        public Collumn Id;
        public Collumn Name;
        public Collumn TP_Number;
        public Collumn Address;
        public Collumn Phone;
        public Collumn Email;
        public Collumn UserId;

        public Student_Table(DataTable dt)
        {
            Id = new Collumn("Id");
            Name = new Collumn("Name");
            TP_Number = new Collumn("TP_Number");
            Address = new Collumn("Address");
            Phone = new Collumn("Phone");
            Email = new Collumn("Email");
            UserId = new Collumn("UserId");

            Add_Collumn(Id);
            Add_Collumn(Name);
            Add_Collumn(TP_Number);
            Add_Collumn(Address);
            Add_Collumn(Phone);
            Add_Collumn(Email);
            Add_Collumn(UserId);
            Add_Rows(dt);
            
        }


    }
}
