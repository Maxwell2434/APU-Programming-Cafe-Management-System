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
        private List<Collumn> collumns = new List<Collumn>();
        private List<Row> rows = new List<Row>(); 


        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public List<Collumn> Collumns 
        {
            get { return collumns; }
            set { collumns = value; }
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
        public void Add_Collumn (Collumn collumn)
        {
            collumns.Add(collumn);
        }

        public void Add_Rows (DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                rows.Add(new Row(dr, collumns));
            }
        }



        public Collumn Get_Collumn(string Name)
        {
            return (collumns.Find(Collumn => Collumn.Name == Name));
        }

        public Collumn Get_Primary_Key_Collumn()
        {
            return (collumns.Find(Collumn => Collumn.IsKey == true));
        }
        public List<Row> Search_Row_For_Value(Collumn collumn, string value)
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
                if (row.values[Get_Collumn(collumnName)] == value)
                {
                    result.Add(row);
                }
            }
            return result;
        }





    }
}
