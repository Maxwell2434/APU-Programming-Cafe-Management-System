using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace APU_Programming_Café_Management_System.AdminForm
{
    public partial class TrainerListAdd : UserControl
    {
        TrainerList trainerList;
        public TrainerListAdd(TrainerList trainerList)
        {
            InitializeComponent();
            this.trainerList = trainerList;
        }

        private void TrainerListAdd_Load(object sender, EventArgs e)
        {

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
            List<string> trainerValues = new List<string>
            {
                    "",
                    txtBoxName.Text,
                    txtBoxAddress.Text,
                    txtBoxPhone.Text,
                    txtBoxEmail.Text,
            };

            if (Check_If_Empty(userValues))
            {
                MessageBox.Show("User section contains empty values");
            }
            else if(Check_If_Empty(trainerValues))
            {
                MessageBox.Show("Trainer section contains empty values");
            }
            else
            {
                //Record the number of rows in userTable
                int rowCount = Programming_Café_DB.userTable.Rows.Count;

                //Insert new User
                Programming_Café_DB.userTable.Insert_Row(userValues, Programming_Café_DB.userTable.Columns);


                //Check if a new User has been created if Yes then associate the new User as a trainer
                if(rowCount < Programming_Café_DB.userTable.Rows.Count)
                {
                    //Find The Id in the newly created row in the userTable
                    List<Row> rows = Programming_Café_DB.userTable.Search_Row_For_Username_Value(txtBoxUsername.Text);
                    string UserId = rows[0].values[Programming_Café_DB.userTable.Id];

                    //Add the foreign key, userId to the trainerValues
                    trainerValues.Add(UserId);

                    Programming_Café_DB.trainerTable.Insert_Row(trainerValues, Programming_Café_DB.trainerTable.Columns);
                    trainerList.Load_Trainer_ListView();
                    this.Dispose();

                }

            }
            
        }

        private bool Check_If_Empty(List<string> value)
        {
            bool is_Empty = false;
            //starts at 1 because the first value is always empty
            for(int i = 1; i < value.Count; i++)
            {
                if (value[i] == null || value[i] == "")
                {
                    is_Empty= true;
                }
            }
            return is_Empty;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
