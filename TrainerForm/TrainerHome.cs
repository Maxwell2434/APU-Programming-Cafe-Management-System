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
    public partial class TrainerHome : UserControl
    {
        Trainer trainer;
        public TrainerHome(Trainer trainer)
        {
            InitializeComponent();
            this.trainer = trainer;
        }

        private void TrainerHome_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + trainer.Name;

        }
    }
}
