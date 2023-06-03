using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    internal class StudentTable : System.Data.DataTable
    {
        private DataTable datatable;

        private DataColumn columnId;

        private DataColumn columnStudentName;

        private DataColumn columnTP_Number;

        private DataColumn columnAddress;

        private DataColumn columnPhoneNumber;

        private DataColumn columnEmail;
         
        public StudentTable(DataTable dt) 
        {
            this.datatable = dt;
            this.columnId = dt.Columns["id"];
            this.columnStudentName = dt.Columns["StudentName"];
            this.columnTP_Number = dt.Columns["TP_Number"];
            this.columnAddress = dt.Columns["Address"];
            this.columnPhoneNumber = dt.Columns["PhoneNumber"];
            this.columnEmail = dt.Columns["Email"];
        }

        

    

       

        public void initialize()
        {
            /*connectionString = ConfigurationManager.ConnectionStrings["APU_Programming_Café_Management_System_DB"].ConnectionString;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
            }
            */
        }
  

        

    }
}
