namespace APU_Programming_Café_Management_System.TrainerForm
{
    partial class TrainerStudents
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
            this.lstView = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxModule = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lstView
            // 
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(127, 157);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(546, 199);
            this.lstView.TabIndex = 9;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(122, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 25);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Students Handled by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(124, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Module :";
            // 
            // cmbBoxModule
            // 
            this.cmbBoxModule.FormattingEnabled = true;
            this.cmbBoxModule.Location = new System.Drawing.Point(127, 112);
            this.cmbBoxModule.Name = "cmbBoxModule";
            this.cmbBoxModule.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxModule.TabIndex = 41;
            this.cmbBoxModule.SelectedIndexChanged += new System.EventHandler(this.cmbBoxModule_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(251, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Level :";
            // 
            // cmbBoxLevel
            // 
            this.cmbBoxLevel.FormattingEnabled = true;
            this.cmbBoxLevel.Location = new System.Drawing.Point(254, 112);
            this.cmbBoxLevel.Name = "cmbBoxLevel";
            this.cmbBoxLevel.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxLevel.TabIndex = 43;
            this.cmbBoxLevel.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLevel_SelectedIndexChanged);
            // 
            // TrainerStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBoxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxModule);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstView);
            this.Name = "TrainerStudents";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.TrainerStudents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxLevel;
    }
}
