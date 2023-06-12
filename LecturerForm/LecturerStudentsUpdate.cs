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

namespace APU_Programming_Café_Management_System.LecturerForm
{
    public partial class LecturerStudentsUpdate : UserControl
    {
        Row studentModuleRow;
        LecturerStudents lecturerStudents;
        public LecturerStudentsUpdate(Row studentModuleRow, LecturerStudents lecturerStudents)
        {
            InitializeComponent();
            this.studentModuleRow = studentModuleRow;
            this.lecturerStudents = lecturerStudents;
            foreach (Row row in Programming_Café_DB.moduleTable.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.moduleTable.Name]);
            }
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");
        }

        private void LecturerStudentsUpdate_Load(object sender, EventArgs e)
        {
            string studentId = studentModuleRow.values[Programming_Café_DB.studentModuleTable.StudentId];
            Column columnToSearch = Programming_Café_DB.studentTable.Id;
            Column columnToReturn = Programming_Café_DB.studentTable.Name;
            string StudentName = Programming_Café_DB.studentTable.Get_ColumnValue_From_Row(columnToSearch, studentId, columnToReturn);

            string moduleId = studentModuleRow.values[Programming_Café_DB.studentModuleTable.ModuleId];
            columnToSearch = Programming_Café_DB.moduleTable.Id;
            columnToReturn = Programming_Café_DB.moduleTable.Name;
            string moduleName = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, moduleId, columnToReturn);

            string level = studentModuleRow.values[Programming_Café_DB.studentModuleTable.Level];
            lblTitle.Text = "Update Student " + StudentName + " Enrolled Module and Class";
            
            cmbBoxModule.Text = moduleName;
            cmbBoxLevel.Text = level;
            
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

            StudentModule_Table studentModuleTable = Programming_Café_DB.studentModuleTable;
            string tableName = studentModuleTable.TableName;
            Column columnToSearch = Programming_Café_DB.moduleTable.Name;
            string moduleName = cmbBoxModule.Text;
            Column columnToReturn = Programming_Café_DB.moduleTable.Id;
            string moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, moduleName, columnToReturn);

            bool ModuleAndLevelExists = false;
            columnToSearch = studentModuleTable.StudentId;
            foreach(Row row in studentModuleTable.Search_Row_For_Value(columnToSearch, studentModuleRow.values[columnToSearch]))
            {
                if (row.values[studentModuleTable.ModuleId] == moduleId && row.values[studentModuleTable.Level] == cmbBoxLevel.Text)
                {
                    if(row != studentModuleRow)
                    {
                        ModuleAndLevelExists = true;
                    }
                }
            }
           
            if(ModuleAndLevelExists)
            {
                MessageBox.Show("Module and Level Exists already");
            }
            else
            {
                Dictionary<Column, string> values = new Dictionary<Column, string>();
                foreach (KeyValuePair<Column, string> kvp in studentModuleRow.values)
                {
                    values.Add(kvp.Key, kvp.Value);
                }

                values[studentModuleTable.ModuleId] = moduleId;
                values[studentModuleTable.Level] = cmbBoxLevel.Text;
                values[studentModuleTable.ClassId] = cmbBoxClassId.Text;
                studentModuleRow.values = values;

                Programming_Café_DB.studentModuleTable.Refresh_Table_Values();
                lecturerStudents.Load_List_View();
                this.Dispose();
            }
            
            

            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RefreshClassIdList()
        {
            //Clear the combobox first
            cmbBoxClassId.Items.Clear();
            cmbBoxClassId.Text = string.Empty;
            lblTrainer.Text = "Trainer :";

            //Get Module Id and Level
            string moduleName = cmbBoxModule.Text;
            Column columnToSearch = Programming_Café_DB.moduleTable.Name;
            Column columnToReturn = Programming_Café_DB.moduleTable.Id;
            string moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, moduleName, columnToReturn);
            string level = cmbBoxLevel.Text;

            //Filter class rows by moduleId and level
            columnToSearch = Programming_Café_DB.classTable.ModuleId;
            foreach(Row classRowByModuleId in Programming_Café_DB.classTable.Search_Row_For_Value(columnToSearch, moduleId))
            {
                if (classRowByModuleId.values[Programming_Café_DB.classTable.Level] == level)
                {
                    //Add the classId which has the same module and level
                    cmbBoxClassId.Items.Add(classRowByModuleId.values[Programming_Café_DB.classTable.Id]);
                    

                }
            }
        }

        private void cmbBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxModule.Text != "")
            {
                RefreshClassIdList();
            }
        }

        private void cmbBoxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxLevel.Text != "")
            {
                RefreshClassIdList();
            }
        }

        private void cmbBoxClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get trainer Id who is responsible for the class
            string classId = cmbBoxClassId.Text;
            Column columnToSearch = Programming_Café_DB.classTable.Id;
            Column columnToReturn = Programming_Café_DB.classTable.TrainerId;
            string trainerId = Programming_Café_DB.classTable.Get_ColumnValue_From_Row(columnToSearch, classId, columnToReturn);

            //Get trainerName from trainerTable and set the lblTrainer.text to the trainerName 
            columnToSearch = Programming_Café_DB.trainerTable.Id;
            columnToReturn = Programming_Café_DB.trainerTable.Name;
            string trainerName = Programming_Café_DB.trainerTable.Get_ColumnValue_From_Row(columnToSearch, trainerId, columnToReturn);
            lblTrainer.Text = "Trainer :" + trainerName;
        }
    }
}
