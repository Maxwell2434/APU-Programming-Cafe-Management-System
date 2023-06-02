using System;
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
        private static Administrator_Table _adminTable;
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

        public static Administrator_Table adminTable
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

        public static void Update_Table_Database(string tableName, Row rowToBeUpdated, Dictionary<Collumn, string> values)
        {
            string commandString = "UPDATE " + tableName + " SET ";
            string p_Key = "";
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
                else if (string.IsNullOrEmpty(p_Key))
                {
                    p_Key = kvp.Key.Name;
                }
            }

            // Remove trailing comma and space
            commandString = commandString.TrimEnd(',', ' ');

            // Add WHERE clause
            commandString += " WHERE " + p_Key + " = @" + p_Key;

            // Add parameter for the primary key value
            SqlParameter primaryKeyParameter = new SqlParameter("@" + p_Key, rowToBeUpdated.values[Programming_Café_DB.adminTable.Id]);
            parameters.Add(primaryKeyParameter);

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                cmd.ExecuteNonQuery();
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