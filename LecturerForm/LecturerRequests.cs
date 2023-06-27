using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerRequests : UserControl
    {
        public LecturerRequests()
        {
            InitializeComponent();
        }

        private void LecturerRequests_Load(object sender, EventArgs e)
        {

        }

        public void Load_List_View()
        {
            lstView.Items.Clear();
            //Get all columns & rows from RequestTable
            Request_Table RequestTable = Programming_Café_DB.requestTable;
            List<Column> columns = RequestTable.Columns;
            List<Row> rows = RequestTable.Rows;
            
            
            Column columnToSearch;
            Column columnToReturn;

            List<Column> newColumns = new List<Column>
            {
                new Column("Student Name"),
                new Column("Module Name"),
                RequestTable.Level,
            };

            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                //Get Student Name
                columnToSearch = Programming_Café_DB.studentTable.Id;
                columnToReturn = Programming_Café_DB.studentTable.Name;
                string studentName = Programming_Café_DB.studentTable.GetColumnValueFromRow(columnToSearch, rows[i].values[RequestTable.StudentId], columnToReturn);

                //Get Module Name
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleName = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, rows[i].values[RequestTable.ModuleId], columnToReturn);

                //Get Level
                string Level = rows[i].values[RequestTable.Level];

                List<string> arr_values = new List<string>
                {
                    studentName,
                    ModuleName,
                    Level,

                };

                newRows.Add(new Row("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Student Name",
                "Module Name",
                "Level",
            };

            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }
            if (itemIndexes.Count == 1)
            {
                Row selectedRow = Programming_Café_DB.requestTable.Rows[itemIndexes[0]];
                string studentId = selectedRow.values[Programming_Café_DB.requestTable.StudentId];
                string moduleId = selectedRow.values[Programming_Café_DB.requestTable.ModuleId];
                string level = selectedRow.values[Programming_Café_DB.requestTable.Level];
                string EnrollmentMonth = DateTime.Now.Month.ToString();
                List<string> studentModuleValues = new List<string>()
                {
                    studentId,
                    moduleId,
                    level,
                    "",
                    "UnPaid",
                    EnrollmentMonth
                };
                List<Column> uniqueColumns = new List<Column>
                    {
                        Programming_Café_DB.studentModuleTable.StudentId,
                        Programming_Café_DB.studentModuleTable.ModuleId,
                        Programming_Café_DB.studentModuleTable.Level
                    };
                Programming_Café_DB.studentModuleTable.InsertRow(studentModuleValues, uniqueColumns);
                Row rowToBeDeleted = Programming_Café_DB.requestTable.Rows[itemIndexes[0]];
                Programming_Café_DB.requestTable.DelRow(rowToBeDeleted);
                Load_List_View();
            }
            else
            {
                MessageBox.Show("Please Select a Request");
            }

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }
            if (itemIndexes.Count == 1)
            {
                Row rowToBeDeleted = Programming_Café_DB.requestTable.Rows[itemIndexes[0]];
                Programming_Café_DB.requestTable.DelRow(rowToBeDeleted);
                Load_List_View();
            }
            else
            {
                MessageBox.Show("Please Select a Request");
            }
        }

     
    }
}
