using APU_Programming_Café_Management_System.Tables;
using APU_Programming_Café_Management_System.TrainerForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.AdminForm
{
    public partial class AdminIncome : UserControl
    {
        public AdminIncome()
        {
            InitializeComponent();
        }

        private void AdminIncome_Load(object sender, EventArgs e)
        {
            Load_ListView();
        }

        public void Load_ListView()
        {
            lstView.Items.Clear();
            //Get all columns & rows from matching trainerId from classTable
            Class_Table ClassTable = Programming_Café_DB.classTable;
            List<Column> columns = ClassTable.Columns;
            Column columnToSearch;
            Column columnToReturn;

            List<Row> rows = ClassTable.Rows;

            List<Column> newColumns = new List<Column>
            {
                new Column("Trainer Name"),
                new Column("Module Name"),
                Programming_Café_DB.classTable.Level,
                Programming_Café_DB.classTable.Fee,
                new Column("Number of Students"),
                new Column("Income")
            };


            int totalIncome = 0;
            List<Row> newRows = new List<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                //Get Trainer Name
                columnToSearch = Programming_Café_DB.trainerTable.Id;
                columnToReturn = Programming_Café_DB.trainerTable.Name;
                string trainerName = Programming_Café_DB.trainerTable.GetColumnValueFromRow(columnToSearch, rows[i].values[Programming_Café_DB.classTable.TrainerId], columnToReturn);

                //Get Module Name
                columnToSearch = Programming_Café_DB.moduleTable.Id;
                columnToReturn = Programming_Café_DB.moduleTable.Name;
                string ModuleName = Programming_Café_DB.moduleTable.GetColumnValueFromRow(columnToSearch, rows[i].values[Programming_Café_DB.classTable.ModuleId], columnToReturn);
                
                //Get Level
                string Level = rows[i].values[Programming_Café_DB.classTable.Level];

                //Get Fee
                string Fee = rows[i].values[Programming_Café_DB.classTable.Fee];

                //Get number of students in the class
                string classId = rows[i].values[Programming_Café_DB.classTable.Id];
                List<Row> studentRowsByClassId = Programming_Café_DB.studentModuleTable.SearchRowForValue(Programming_Café_DB.studentModuleTable.ClassId, classId);
                int numberOfStudents = studentRowsByClassId.Count;

                int income = Convert.ToInt32(Fee) * numberOfStudents;
                totalIncome += income;
                List<string> arr_values = new List<string>
                {
                    trainerName,
                    ModuleName,
                    Level,
                    Fee,
                    numberOfStudents.ToString(),
                    income.ToString(),

                };

                newRows.Add(new Row("", newColumns, arr_values));
            }

            //Filter the columns
            List<string> columnsToInclude = new List<string>
            {
                "Trainer Name",
                "Module Name",
                "Level",
                "Fee",
                "Number of Students",
                "Income"
            };

            AdminUI.SetupListView(lstView, newColumns, newRows, columnsToInclude);
            lblTotalIncome.Text = "Total Income:" + totalIncome;



        }

        private void lstView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstView.Sorting == SortOrder.None)
            {
                lstView.Sorting = SortOrder.Ascending;
            }
            else if (lstView.Sorting == SortOrder.Ascending)
            {
                lstView.Sorting = SortOrder.Descending;
            }
            else if (lstView.Sorting == SortOrder.Descending)
            {
                lstView.Sorting = SortOrder.None;
            }

            lstView.Sort();
        }
    }
}
