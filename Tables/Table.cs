using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace APU_Programming_Café_Management_System
{
    public class Table
    {
        //Fields
        private string tableName;
        private List<Column> columns = new List<Column>();
        private List<Row> rows = new List<Row>(); 

        //Properties
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public List<Column> Columns 
        {
            get { return columns; }
            set { columns = value; }
        }
        public List<Row> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        //Methods
        public void AddColumn (Column column)
        {
            columns.Add(column);
        }
        public void AddRows (DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                rows.Add(new Row(dr, columns));
            }
        }
        public void InsertRow(List<string> values, List<Column> uniqueColumns)
        {
            //uniqueColumns is a list to contain the columns that must not have the same values as another row in the table
            Row rowToBeInserted = new Row(this.tableName, this.columns, values);
            rows.Add(rowToBeInserted);
            Programming_Café_DB.InsertRowDatabase(this, rowToBeInserted, uniqueColumns);
            RefreshTableValues();
        }
        public void InsertRow(Row rowToBeInserted)
        {
            rows.Add(rowToBeInserted);
            Programming_Café_DB.InsertRowDatabase(this, rowToBeInserted, columns);
            RefreshTableValues();
        }
        public void DelRow (List<string> values)
        {
            Row rowToBeDeleted = new Row(this.TableName, this.columns, values);
            rows.Remove(rowToBeDeleted);
            Programming_Café_DB.DeleteRowDatabase(this, rowToBeDeleted);
            RefreshTableValues();
        }
        public void DelRow (Row rowToBeDeleted)
        {
            rows.Remove(rowToBeDeleted);
            Programming_Café_DB.DeleteRowDatabase(this, rowToBeDeleted);
            RefreshTableValues();
        }
        public Column GetColumn(string Name)
        {
            return (columns.Find(Collumn => Collumn.Name == Name));
        }
        public string GetColumnValueFromRow(Column columnToSearch, string value, Column columnToReturn)
        {
            List<Row> rows = SearchRowForValue(columnToSearch, value);
            if(rows.Count>0)
            {
                return (rows[0].values[columnToReturn]);
            }
            else
            {
                return null;
            }
        }
        public List<Row> SearchRowForValue(Column column, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in Rows)
            {
                if (row.values[column] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }
        public List<Row> SearchRowForValue(string columnName, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in Rows)
            {
                if (row.values[GetColumn(columnName)] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }
        public void RefreshTableValues()
        {
            rows.Clear();
            AddRows(Programming_Café_DB.GetDataTableFromTable(tableName));
        }


    }
}
