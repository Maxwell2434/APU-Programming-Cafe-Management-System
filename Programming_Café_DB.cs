﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APU_Programming_Café_Management_System
{
    public class Programming_Café_DB
    {
        //Fields
        public static string connectionString;

        private DataSet _dataset;
        SqlConnection connection;
        private Administrator_Table _adminTable;
        private Student_Table _studentTable;
        private User_Table _userTable;
       
        //Constructor
        public Programming_Café_DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["APU_Programming_Café_Management_System_DB"].ConnectionString;
            _dataset = dataSet;
            _studentTable = new Student_Table(dataSet.Tables["Students"]);
            userTable = new User_Table(_dataset.Tables["Users"]);
            _adminTable = new Administrator_Table(_dataset.Tables["Administrators"]);
        }

        //Property
        public DataSet dataSet
        {
            get
            {
                List<string> tableNames = Get_Table_List();
                DataSet ds = new DataSet();
                int i = 0;
                foreach (string tableName in tableNames)
                {
                    ds.Tables.Add(Get_DataTable_From_Table(tableName));
                    ds.Tables[i].TableName = tableName;
                    i++;
                }
                

                return ds;
            }
        }


        public Student_Table studentTable
        {
            get { return _studentTable; }
            set { _studentTable = value; }
        }

        public User_Table userTable
        {
            get { return _userTable; }
            set { _userTable = value; }
        }

        public Administrator_Table adminTable
        {
            get { return _adminTable; }
            set { _adminTable = value; }
        }



        //Methods

        //returns a list of strings that contains all the table names inside the database
        public List<string> Get_Table_List()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        //a that takes a parameter of a tablename and then returns a DataTable from the database
        public static DataTable Get_DataTable_From_Table(string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("select * from " + table, connection))
            {
                connection.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return (dt);
            }

        }

        public static void Update_Table_Database(Table table)
        {
            string commandString = "UPDATE " + table.TableName + "SET ";
            string p_Key = "";
            foreach(Collumn collumn in table.Collumns)
            {
                if(collumn.IsKey == false) 
                {
                    commandString += collumn.Name + " ='" + ;
                }
                else if (p_Key == "") 
                { 
                    p_Key = collumn.Name; 
                }
            }
            commandString += "' WHERE " + p_Key + "='" 

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
        }

        public static DataRow[] Get_DataRows_From_DataTable(DataTable dt, string columnName, string value)
        {
            DataRow[] filteredRows = dt.Select(columnName + " = '" + value + "'");
            return filteredRows;
        }

        public static DataRow[] Get_DataRows_From_DataTable(DataTable dt, string columnName, int value)
        {
            string str_value = value.ToString();
            DataRow[] filteredRows = dt.Select(columnName + " = " + value);
            return filteredRows;
        }

    }
}