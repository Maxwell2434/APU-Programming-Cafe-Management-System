﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    public class Programming_Café_DB
    {
        //Fields
        public static string connectionString;
        private DataSet _dataset;
        SqlConnection connection;
        private static Administrator_Table _adminTable;
        private static Trainer_Table _trainerTable;
        private static Student_Table _studentTable;
        private static User_Table _userTable;
       
        //Constructor
        public Programming_Café_DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["APU_Programming_Café_Management_System_DB"].ConnectionString;
            _dataset = dataSet;
            _studentTable = new Student_Table(dataSet.Tables["Students"]);
            userTable = new User_Table(_dataset.Tables["Users"]);
            _adminTable = new Administrator_Table(_dataset.Tables["Administrators"]);
            _trainerTable = new Trainer_Table(_dataset.Tables["Trainers"]);
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


        public static Student_Table studentTable
        {
            get { return _studentTable; }
            set { _studentTable = value; }
        }

        public static User_Table userTable
        {
            get { return _userTable; }
            set { _userTable = value; }
        }

        public static Administrator_Table adminTable
        {
            get { return _adminTable; }
            set { _adminTable = value; }
        }

        public static Trainer_Table trainerTable
        {
            get { return _trainerTable; }
            set { _trainerTable = value; }
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

        public static void Update_Table_Database(string tableName, Row rowToBeUpdated, Dictionary<Collumn, string> values)
        {
            string commandString = "UPDATE " + tableName + " SET ";
            Collumn key = null;
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (KeyValuePair<Collumn, string> kvp in values)
            {
                if (!kvp.Key.IsKey)
                {
                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + ", ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);
                }
                else if (key == null)
                {
                    key = kvp.Key;
                }
            }

            // Remove trailing comma and space
            commandString = commandString.TrimEnd(',', ' ');

            // Add WHERE clause
            commandString += " WHERE " + key.Name + " = @" + key.Name;

            // Add parameter for the primary key value
            SqlParameter primaryKeyParameter = new SqlParameter("@" + key.Name, rowToBeUpdated.values[key]);
            parameters.Add(primaryKeyParameter);

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                cmd.ExecuteScalar();
            }
        }

        public static void Insert_Row_Database(string tableName, Dictionary<Collumn, string> values)
        {
            // Check if the row already exists
            bool rowExists = Check_Row_Exists(tableName, values);
            if (rowExists)
            {
                MessageBox.Show("Row already exists.");
                return;
            }

            string commandString = "INSERT INTO " + tableName + " (";
            string valueString = "VALUES (";
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (KeyValuePair<Collumn, string> kvp in values)
            {
                commandString += kvp.Key.Name + ", ";
                valueString += "@" + kvp.Key.Name + ", ";

                // Add parameter for the value
                SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                parameters.Add(parameter);
            }

            // Remove trailing comma and space
            commandString = commandString.TrimEnd(',', ' ');
            valueString = valueString.TrimEnd(',', ' ');

            // Complete the command and combine the strings
            commandString += ") " + valueString + ")";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool Check_Row_Exists(string tableName, Dictionary<Collumn, string> values)
        {
            string commandString = "SELECT COUNT(*) FROM " + tableName + " WHERE ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (KeyValuePair<Collumn, string> kvp in values)
            {
                commandString += kvp.Key.Name + " = @" + kvp.Key.Name + " AND ";

                // Add parameter for the value
                SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                parameters.Add(parameter);
            }

            // Remove trailing "AND"
            commandString = commandString.Remove(commandString.Length - 5);

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
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