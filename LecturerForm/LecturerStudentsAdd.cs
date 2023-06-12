using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerStudentsAdd : UserControl
    {
        LecturerStudents lecturerStudents;
        public LecturerStudentsAdd(LecturerStudents lecturerStudents)
        {
            InitializeComponent();
            this.lecturerStudents = lecturerStudents;
            foreach (Row row in Programming_Café_DB.moduleTable.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.moduleTable.Name]);
            }
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");
            for(int i = 1; i <= 12; i++)
            {
                cmbBoxEnrollmentMonth.Items.Add(i.ToString());
            }

            foreach (Row row in Programming_Café_DB.studentTable.Rows)
            {
                cmbBoxStudent.Items.Add(row.values[Programming_Café_DB.studentTable.Name]);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            List<string> userValues = new List<string>
            {
                //The first value is an empty string because it is the primary key which cannot be inserted into
                "",
                txtBoxUsername.Text,
                txtBoxPassword.Text,
            };
            //Create the values for the new row in the trainerTable
            List<string> studentValues = new List<string>
            {
                    "",
                    txtBoxName.Text,
                    txtBoxTPNumber.Text,
                    txtBoxAddress.Text,
                    txtBoxPhone.Text,
                    txtBoxEmail.Text,
            };

            if (Check_If_Empty(userValues))
            {
                MessageBox.Show("User section contains empty values");
            }
            else if (Check_If_Empty(studentValues))
            {
                MessageBox.Show("Student section contains empty values");
            }
            else if (cmbBoxModule.Text == "")
            {
                MessageBox.Show("Module section contains empty values");
            }
            else if (cmbBoxLevel.Text == "")
            {
                MessageBox.Show("Level section contains empty values");
            }
            else if (cmbBoxEnrollmentMonth.Text == "")
            {
                MessageBox.Show("Enrollment Month section contains empty values");
            }
            else
            {

                string UserId;
                //Check if username exists
                int count = Programming_Café_DB.userTable.Search_Row_For_Username_Value(txtBoxUsername.Text).Count;
                if (count == 0)
                {

                    //If username doesnt exist then Insert new User
                    Programming_Café_DB.userTable.Insert_Row(userValues, Programming_Café_DB.userTable.Columns);

                    //Find The Id in the newly created row in the userTable
                    List<Row> rows = Programming_Café_DB.userTable.Search_Row_For_Username_Value(txtBoxUsername.Text);
                    UserId = rows[0].values[Programming_Café_DB.userTable.Id];

                    //Add the foreign key, userId to the studentValues
                    studentValues.Add(UserId);

                    //insert a row in the studentTable
                    Programming_Café_DB.studentTable.Insert_Row(studentValues, Programming_Café_DB.studentTable.Columns);

                }

                //Create an entry in the studentModules table
                Column columnToSearch = Programming_Café_DB.userTable.Username;
                Column columnToReturn = Programming_Café_DB.userTable.Id;
                UserId = Programming_Café_DB.userTable.Get_ColumnValue_From_Row(columnToSearch, txtBoxUsername.Text, columnToReturn);

                columnToSearch = Programming_Café_DB.studentTable.UserId;
                columnToReturn = Programming_Café_DB.studentTable.Id;
                string StudentId = Programming_Café_DB.studentTable.Get_ColumnValue_From_Row(columnToSearch, UserId, columnToReturn);

                columnToSearch = Programming_Café_DB.moduleTable.Name;
                columnToReturn = Programming_Café_DB.moduleTable.Id;
                string moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, cmbBoxModule.Text, columnToReturn);
                List<string> studentModuleValues = new List<string>()
                    {
                        StudentId,
                        moduleId,
                        cmbBoxLevel.Text,
                        "",
                        "UnPaid",
                        cmbBoxEnrollmentMonth.Text
                    };

                List<Column> uniqueColumns = new List<Column>
                    {
                        Programming_Café_DB.studentModuleTable.StudentId,
                        Programming_Café_DB.studentModuleTable.ModuleId,
                        Programming_Café_DB.studentModuleTable.Level
                    };
                Programming_Café_DB.studentModuleTable.Insert_Row(studentModuleValues, uniqueColumns);
                lecturerStudents.Load_List_View();
                this.Dispose();
                

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool Check_If_Empty(List<string> value)
        {
            bool is_Empty = false;
            //starts at 1 because the first value is always empty
            for (int i = 1; i < value.Count; i++)
            {
                if (value[i] == null || value[i] == "")
                {
                    is_Empty = true;
                }
            }
            return is_Empty;
        }

        private void cmbBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student_Table studentTable = Programming_Café_DB.studentTable;
            string studentName = cmbBoxStudent.Text;
            Column columnToSearch = studentTable.Name;
            Column columnToReturn = studentTable.Id;
            string studentId = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToReturn = studentTable.TP_Number;
            string TP_Number = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToReturn = studentTable.Address;
            string address = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToReturn = studentTable.Phone;
            string phone = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToReturn = studentTable.Email;
            string email = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToReturn = studentTable.UserId;
            string userId = studentTable.Get_ColumnValue_From_Row(columnToSearch, studentName, columnToReturn);

            columnToSearch = Programming_Café_DB.userTable.Id;
            columnToReturn = Programming_Café_DB.userTable.Username;
            string username = Programming_Café_DB.userTable.Get_ColumnValue_From_Row(columnToSearch, userId, columnToReturn);

            columnToReturn = Programming_Café_DB.userTable.Password;
            string password = Programming_Café_DB.userTable.Get_ColumnValue_From_Row(columnToSearch, userId, columnToReturn);

            txtBoxName.Text = studentName;
            txtBoxTPNumber.Text = TP_Number;
            txtBoxAddress.Text = address;
            txtBoxPhone.Text = phone;
            txtBoxEmail.Text = email;
            txtBoxUsername.Text = username;
            txtBoxPassword.Text = password;

        }
    }
}
