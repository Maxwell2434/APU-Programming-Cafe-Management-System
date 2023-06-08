﻿namespace APU_Programming_Café_Management_System.TrainerForm
{
    partial class TrainerClassesAdd
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBoxFee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBoxEndHour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoxStartHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoxScheduleDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxModule = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(533, 308);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 36;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Location = new System.Drawing.Point(623, 308);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(334, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Fee :";
            // 
            // cmbBoxFee
            // 
            this.cmbBoxFee.FormattingEnabled = true;
            this.cmbBoxFee.Items.AddRange(new object[] {
            "200",
            "300",
            "400",
            "500",
            "600",
            "700"});
            this.cmbBoxFee.Location = new System.Drawing.Point(337, 243);
            this.cmbBoxFee.Name = "cmbBoxFee";
            this.cmbBoxFee.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxFee.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(500, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "End Hour :";
            // 
            // cmbBoxEndHour
            // 
            this.cmbBoxEndHour.FormattingEnabled = true;
            this.cmbBoxEndHour.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbBoxEndHour.Location = new System.Drawing.Point(503, 160);
            this.cmbBoxEndHour.Name = "cmbBoxEndHour";
            this.cmbBoxEndHour.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxEndHour.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(334, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Start Hour :";
            // 
            // cmbBoxStartHour
            // 
            this.cmbBoxStartHour.FormattingEnabled = true;
            this.cmbBoxStartHour.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbBoxStartHour.Location = new System.Drawing.Point(337, 160);
            this.cmbBoxStartHour.Name = "cmbBoxStartHour";
            this.cmbBoxStartHour.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxStartHour.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(170, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Schedule Day :";
            // 
            // cmbBoxScheduleDay
            // 
            this.cmbBoxScheduleDay.FormattingEnabled = true;
            this.cmbBoxScheduleDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbBoxScheduleDay.Location = new System.Drawing.Point(173, 160);
            this.cmbBoxScheduleDay.Name = "cmbBoxScheduleDay";
            this.cmbBoxScheduleDay.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxScheduleDay.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(412, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Level :";
            // 
            // cmbBoxLevel
            // 
            this.cmbBoxLevel.FormattingEnabled = true;
            this.cmbBoxLevel.Location = new System.Drawing.Point(415, 77);
            this.cmbBoxLevel.Name = "cmbBoxLevel";
            this.cmbBoxLevel.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxLevel.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(248, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "Module :";
            // 
            // cmbBoxModule
            // 
            this.cmbBoxModule.FormattingEnabled = true;
            this.cmbBoxModule.Location = new System.Drawing.Point(251, 77);
            this.cmbBoxModule.Name = "cmbBoxModule";
            this.cmbBoxModule.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxModule.TabIndex = 39;
            // 
            // TrainerClassesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBoxFee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbBoxEndHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBoxStartHour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBoxScheduleDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBoxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxModule);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Name = "TrainerClassesAdd";
            this.Size = new System.Drawing.Size(800, 406);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBoxFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBoxEndHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxStartHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBoxScheduleDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxModule;
    }
}