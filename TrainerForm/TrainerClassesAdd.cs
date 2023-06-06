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
    public partial class TrainerClassesAdd : UserControl
    {
        TrainerClasses trainerClasses;
        public TrainerClassesAdd(TrainerClasses trainerClasses)
        {
            InitializeComponent();
            this.trainerClasses = trainerClasses;
        }
    }
}
