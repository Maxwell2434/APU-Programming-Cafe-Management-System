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
        public Column Id;
        public Column Name;
        public Column TP_Number;
        public Column Address;
        public Column Phone;
        public Column Email;
        public Column UserId;

        public Student_Table(DataTable dt)
        {
            Id = new Column("Id");
            Name = new Column("Name");
            TP_Number = new Column("TP_Number");
            Address = new Column("Address");
            Phone = new Column("Phone");
            Email = new Column("Email");
            UserId = new Column("UserId");

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
