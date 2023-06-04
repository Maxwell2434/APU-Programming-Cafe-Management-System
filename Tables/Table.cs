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
        private string tableName;
        private List<Column> columns = new List<Column>();
        private List<Row> rows = new List<Row>(); 


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
       
        //Constructor
        /*
        public Table(string tableName, List<Collumn> collumns, List<Row> rows)
        {
            this.tableName = tableName;
            this.collumns = collumns;
            this.rows = rows;
        }
        */
        public void Add_Collumn (Column collumn)
        {
            columns.Add(collumn);
        }

        public void Add_Rows (DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                rows.Add(new Row(dr, columns));
            }
        }

        //uniqueColumns is a list to contain the columns that must not have the same values as another row in the table
        public void Insert_Row(List<string> values, List<Column> uniqueColumns)
        {
            Row rowToBeInserted = new Row(this.tableName, this.columns, values);
            rows.Add(rowToBeInserted);
            Programming_Café_DB.Insert_Row_Database(this, rowToBeInserted, uniqueColumns);
            Refresh_Table_Values();
        }



        public void Del_Row (List<string> values)
        {
            Row rowToBeDeleted = new Row(this.TableName, this.columns, values);
            rows.Remove(rowToBeDeleted);
            Programming_Café_DB.Delete_Row_Database(this, rowToBeDeleted);
            Refresh_Table_Values();
        }

        public void Del_Row (Row rowToBeDeleted)
        {
            rows.Remove(rowToBeDeleted);
            Programming_Café_DB.Delete_Row_Database(this, rowToBeDeleted);
            Refresh_Table_Values();
        }

        public Column Get_Column(string Name)
        {
            return (columns.Find(Collumn => Collumn.Name == Name));
        }

        public Column Get_Primary_Key_Collumn()
        {
            return (columns.Find(Collumn => Collumn.IsPKey == true));
        }

        public string Get_ColumnValue_From_Row(Column columnToSearch, string value, Column columnToReturn)
        {
            List<Row> rows = Search_Row_For_Value(columnToSearch, value);
            if(rows.Count>0)
            {
                return (rows[0].values[columnToReturn]);
            }
            else
            {
                return null;
            }
        }

        public List<Row> Search_Row_For_Value(Column collumn, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in Rows)
            {
                if (row.values[collumn] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }

        public List<Row> Search_Row_For_Value(string collumnName, string value)
        {
            List<Row> result = new List<Row>();
            foreach (Row row in Rows)
            {
                if (row.values[Get_Column(collumnName)] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }

        public void Refresh_Table_Values()
        {
            rows.Clear();
            Add_Rows(Programming_Café_DB.Get_DataTable_From_Table(tableName));
        }



    }
}
