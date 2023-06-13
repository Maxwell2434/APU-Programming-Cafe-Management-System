using APU_Programming_Café_Management_System.Tables;
using APU_Programming_Café_Management_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.StudentForm
{
    public partial class StudentRequests : UserControl
    {
        Student student;
        public StudentRequests(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void StudentRequests_Load(object sender, EventArgs e)
        {

        }

        public void Load_List_View()
        {
            Column columnToSearch;
            Column columnToReturn;

            lstView.Items.Clear();
            //Get all columns from RequestTable
            Request_Table RequestTable = Programming_Café_DB.requestTable;
            List<Column> columns = RequestTable.Columns;

            //Only get the Requests from RequestTable by the current student
            columnToSearch = RequestTable.StudentId;
            List<Row> requestRowsByStudentId = RequestTable.Search_Row_For_Value(columnToSearch, student.Id);



            List<Column> newColumns = new List<Column>
            {
                new Column("Student Name"),
                new Column("Module Name"),
                RequestTable.Level,
            };

            List<Row> newRows = new List<Row>();
            for (int i = 0; i < requestRowsByStudentId.Count; i++)
            {
                //Get Student Name
                columnToSearch = Programming_Café_DB.studentTable.Id;
                columnToReturn = Programming_Café_DB.studentTable.Name;
                string studentName = Programming_Café_DB.studentTable.Get_ColumnValue_From_Row(columnToSearch, requestRowsByStudentId[i].values[RequestTable.StudentId], columnToReturn);

                //Get Module Name
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, requestRowsByStudentId[i].values[RequestTable.ModuleId], columnToReturn);

                //Get Level
                string Level = requestRowsByStudentId[i].values[RequestTable.Level];

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

        private void btnWrite_Click(object sender, EventArgs e)
        {
            StudentRequestsAdd studentRequestsAdd = new StudentRequestsAdd(student, this);
            StudentUI.Initialize_UserControl(studentRequestsAdd, Controls);
            studentRequestsAdd.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> itemIndexes = new List<int>();
            foreach (ListViewItem item in lstView.Items)
            {
                if (item.Checked || item.Selected)
                {
                    itemIndexes.Add(item.Index);

                }
            }
            if (itemIndexes.Count >= 1)
            {
                for (int i = itemIndexes.Count - 1; i >= 0; i--)
                {
                    
                    Row rowToBeDeleted = Programming_Café_DB.requestTable.Rows[itemIndexes[i]];
                    Programming_Café_DB.requestTable.Del_Row(rowToBeDeleted);
                }
              
                Load_List_View();
            }
            else
            {
                MessageBox.Show("Please Select a Request");
            }
        }


        
    }
}
