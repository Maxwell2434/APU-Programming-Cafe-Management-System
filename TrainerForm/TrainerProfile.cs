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

namespace APU_Programming_Café_Management_System.TrainerForm
{
    public partial class TrainerProfile : UserControl
    {
        private Trainer trainer;

        public TrainerProfile(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void TrainerProfile_Load(object sender, EventArgs e)
        {
            txtBoxUsername.Text = trainer.Username;
            txtBoxPassword.Text = trainer.Password;
            txtBoxName.Text = trainer.Name;
            txtBoxAddress.Text = trainer.Address;
            txtBoxPhone.Text = trainer.Phone;
            txtBoxEmail.Text = trainer.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Column columnToSearch = Programming_Café_DB.userTable.Username;
                int count = Programming_Café_DB.userTable.SearchRowForValue(columnToSearch, txtBoxUsername.Text).Count;
                if (count == 0 || trainer.Username == txtBoxUsername.Text)
                {
                    trainer.Username = txtBoxUsername.Text;
                    trainer.Password = txtBoxPassword.Text;
                    trainer.Name = txtBoxName.Text;
                    trainer.Address = txtBoxAddress.Text;
                    trainer.Phone = txtBoxPhone.Text;
                    trainer.Email = txtBoxEmail.Text;
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Username Already Exists");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Save Failed");
            }

        }


    }
}
