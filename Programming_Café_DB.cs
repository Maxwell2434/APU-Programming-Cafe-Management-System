using APU_Programming_Café_Management_System.Tables;
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
        private SqlConnection connection;

        public static Student_Table studentTable;
        public static User_Table userTable;
        public static Administrator_Table administratorTable;
        public static Trainer_Table trainerTable;
        public static Class_Table classTable;
        public static Module_Table moduleTable;
        public static Feedback_Table feedbackTable;
        public static StudentModule_Table studentModuleTable;
        public static Lecturer_Table lecturerTable;
        public static Request_Table requestTable;


        //Properties
        public DataSet dataSet
        {
            get
            {
                List<string> tableNames = GetTableList();
                DataSet ds = new DataSet();
                int i = 0;
                foreach (string tableName in tableNames)
                {
                    ds.Tables.Add(GetDataTableFromTable(tableName));
                    ds.Tables[i].TableName = tableName;
                    i++;
                }


                return ds;
            }
        }

        //Constructor
        public Programming_Café_DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["APU_Programming_Café_Management_System_DB"].ConnectionString;
            _dataset = dataSet;
            studentTable = new Student_Table(_dataset.Tables["Students"]);
            userTable = new User_Table(_dataset.Tables["Users"]);
            administratorTable = new Administrator_Table(_dataset.Tables["Administrators"]);
            trainerTable = new Trainer_Table(_dataset.Tables["Trainers"]);
            classTable = new Class_Table(_dataset.Tables["Classes"]);
            moduleTable = new Module_Table(_dataset.Tables["Modules"]);
            feedbackTable = new Feedback_Table(_dataset.Tables["Feedbacks"]);
            studentModuleTable = new StudentModule_Table(_dataset.Tables["StudentModules"]);
            lecturerTable = new Lecturer_Table(_dataset.Tables["Lecturers"]);
            requestTable = new Request_Table(_dataset.Tables["Requests"]);
        }

        //Methods

        //returns a list of strings that contains all the table names inside the database
        public List<string> GetTableList()
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

        //takes a parameter of a tablename and then returns the corresponding DataTable from the database
        public static DataTable GetDataTableFromTable(string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("select * from " + table, connection))
            {
                connection.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.TableName = table;
                return (dt);
            }

        }

        //Update Table in the database
        public static void UpdateTableDatabase(string tableName, Row rowToBeUpdated, Dictionary<Column, string> values)
        {

            string commandString = "UPDATE " + tableName + " SET ";
            Column key = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            bool primaryKey = false;
            foreach (KeyValuePair<Column, string> kvp in values)
            {
                if (!kvp.Key.IsPKey)
                {
                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + ", ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);
                }
                else if (key == null)
                {
                    key = kvp.Key;
                    primaryKey = true;
                }
            }
            commandString = commandString.TrimEnd(',', ' ');
            // Add WHERE clause
            commandString += " WHERE ";
            //If primary key exists
            if (primaryKey)
            {

                // Add WHERE clause
                commandString += key.Name + " = @" + key.Name;

                // Add parameter for the primary key value
                SqlParameter primaryKeyParameter = new SqlParameter("@" + key.Name, rowToBeUpdated.values[key]);
                parameters.Add(primaryKeyParameter);
            }
            else
            {
                foreach (KeyValuePair<Column, string> kvp in rowToBeUpdated.values)
                {

                    commandString += kvp.Key.Name + " = @n" + kvp.Key.Name + " AND ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@n" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);

                }

                // Remove trailing "AND"
                commandString = commandString.Remove(commandString.Length - 5);
            }


            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                cmd.ExecuteScalar();
            }

        }
        //Insert a row in the specified table in the database
        public static void InsertRowDatabase(Table table, Row rowToBeInserted, List<Column> uniqueColumns)
        {
            // Check if the row already exists
            bool rowExists = CheckRowExists(table, rowToBeInserted, uniqueColumns);
            if (rowExists == false)
            {
                string commandString = "INSERT INTO " + table.TableName + " (";
                string valueString = "VALUES (";
                List<SqlParameter> parameters = new List<SqlParameter>();

                foreach (KeyValuePair<Column, string> kvp in rowToBeInserted.values)
                {
                    if (kvp.Key.IsPKey == false)
                    {
                        commandString += kvp.Key.Name + ", ";
                        valueString += "@" + kvp.Key.Name + ", ";

                        // Add parameter for the value
                        SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                        parameters.Add(parameter);
                    }
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
                    cmd.ExecuteScalar();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Row already exists.");
            }
        }
        //Delete row in the specified table
        public static void DeleteRowDatabase(Table table, Row rowToBeDeleted)
        {
            bool primaryKey = false;
            foreach (Column column in table.Columns)
            {
                //If there is primary key in the columns
                if (column.IsPKey)
                {
                    Column primaryKeyColumn = column;
                    string primaryKeyColumnName = column.Name;
                    string primaryKeyValue = rowToBeDeleted.values[primaryKeyColumn];

                    string commandString = "DELETE FROM " + table.TableName + " WHERE " + primaryKeyColumnName + " = @" + primaryKeyColumnName;
                    SqlParameter parameter = new SqlParameter("@" + primaryKeyColumnName, primaryKeyValue);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandString, connection))
                    {
                        cmd.Parameters.Add(parameter);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    primaryKey = true;
                    break;
                }
            }
            if (primaryKey == false)
            {
                string commandString = "DELETE FROM " + table.TableName + " WHERE ";
                List<SqlParameter> parameters = new List<SqlParameter>();

                foreach (KeyValuePair<Column, string> kvp in rowToBeDeleted.values)
                {

                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + " AND ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);

                }
                if (parameters.Count > 0)
                {
                    // Remove trailing "AND"
                    commandString = commandString.Remove(commandString.Length - 5);

                    // Execute the query
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandString, connection))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        connection.Open();
                        cmd.ExecuteScalar();
                    }
                }
                else
                {
                    MessageBox.Show("Delete failed");
                }
            }



        }
        //check if a row exists in the database table
        public static bool CheckRowExists(Table table, Row row, List<Column> uniqueColumns)
        {
            string commandString = "SELECT COUNT(*) FROM " + table.TableName + " WHERE ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (KeyValuePair<Column, string> kvp in row.values)
            {
                if (kvp.Key.Name == "Username" || kvp.Key.Name == "UserId")
                {
                    if (Get_DataRows_From_DataTable(GetDataTableFromTable(table.TableName), kvp.Key.Name, kvp.Value).Length > 0)

                    //if (table.Search_Row_For_Value(kvp.Key, kvp.Value).Count > 0)
                    {
                        return true;
                    }
                }

                if (uniqueColumns.Contains(kvp.Key))
                {
                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + " AND ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);
                }

            }
            if (parameters.Count > 0)
            {
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
            return false;

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