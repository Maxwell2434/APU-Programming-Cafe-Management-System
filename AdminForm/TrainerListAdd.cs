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
        public TrainerListAdd()
        {
            InitializeComponent();
        }

        private void TrainerListAdd_Load(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Dictionary<Collumn, string> values = new Dictionary<Collumn, string>();
            string[] userValues =
            {
                "",
                txtBoxUsername.Text,
                txtBoxPassword.Text,
            };
            for (int i = 0; i < Programming_Café_DB.userTable.Collumns.Count; i++)
            {
                values.Add(Programming_Café_DB.userTable.Collumns[i], userValues[i]);
            }
            
            //Row row = new Row(Programming_Café_DB.userTable.TableName, values, Programming_Café_DB.userTable.Collumns);
            Programming_Café_DB.Insert_Row_Database(Programming_Café_DB.userTable.TableName, values);

            Trainer_Table trainerTable = Programming_Café_DB.trainerTable;
            values = new Dictionary<Collumn, string>();
            string[] trainerValues =
            {
                "",
                txtBoxName.Text,
                txtBoxAddress.Text,
                txtBoxPhone.Text,
                txtBoxEmail.Text,
                ""
            };
            for (int i = 0; i < Programming_Café_DB.userTable.Collumns.Count; i++)
            {
                values.Add(Programming_Café_DB.userTable.Collumns[i], userValues[i]);
            }
            Programming_Café_DB.Insert_Row_Database(Programming_Café_DB.trainerTable.TableName, values);
            this.Dispose();
        }
    }
}
