﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    public partial class AdminHomePage : Form
    {
        private Administrator administrator;



        public AdminHomePage(Programming_Café_DB programming_Café_DB, string UserId)
        {
            InitializeComponent();
            administrator = new Administrator(UserId);
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            adminProfilePage.administrator = administrator;

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            adminProfilePage.Visible = true;

        }

        private void adminProfilePage_Load(object sender, EventArgs e)
        {
        }
    }
}
