namespace APU_Programming_Café_Management_System.LecturerForm
{
    partial class LecturerStudentsUpdate
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
            this.btnAssign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxModule = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoxClassId = new System.Windows.Forms.ComboBox();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(570, 333);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 36;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAssign.Location = new System.Drawing.Point(660, 333);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 31);
            this.btnAssign.TabIndex = 35;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(315, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Level :";
            // 
            // cmbBoxLevel
            // 
            this.cmbBoxLevel.FormattingEnabled = true;
            this.cmbBoxLevel.Location = new System.Drawing.Point(318, 182);
            this.cmbBoxLevel.Name = "cmbBoxLevel";
            this.cmbBoxLevel.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxLevel.TabIndex = 33;
            this.cmbBoxLevel.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(151, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Module :";
            // 
            // cmbBoxModule
            // 
            this.cmbBoxModule.FormattingEnabled = true;
            this.cmbBoxModule.Location = new System.Drawing.Point(154, 182);
            this.cmbBoxModule.Name = "cmbBoxModule";
            this.cmbBoxModule.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxModule.TabIndex = 31;
            this.cmbBoxModule.SelectedIndexChanged += new System.EventHandler(this.cmbBoxModule_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(73, 57);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 25);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "Update";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(483, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "Class Id :";
            // 
            // cmbBoxClassId
            // 
            this.cmbBoxClassId.FormattingEnabled = true;
            this.cmbBoxClassId.Location = new System.Drawing.Point(486, 182);
            this.cmbBoxClassId.Name = "cmbBoxClassId";
            this.cmbBoxClassId.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxClassId.TabIndex = 48;
            this.cmbBoxClassId.SelectedIndexChanged += new System.EventHandler(this.cmbBoxClassId_SelectedIndexChanged);
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTrainer.Location = new System.Drawing.Point(483, 123);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new System.Drawing.Size(56, 16);
            this.lblTrainer.TabIndex = 50;
            this.lblTrainer.Text = "Trainer :";
            // 
            // LecturerStudentsUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.lblTrainer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBoxClassId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBoxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxModule);
            this.Name = "LecturerStudentsUpdate";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.LecturerStudentsUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxModule;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxClassId;
        private System.Windows.Forms.Label lblTrainer;
    }
}
