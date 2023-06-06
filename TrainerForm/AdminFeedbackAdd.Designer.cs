namespace APU_Programming_Café_Management_System.TrainerForm
{
    partial class AdminFeedbackAdd
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
            this.cmbBoxAdmin = new System.Windows.Forms.ComboBox();
            this.rchTxtBoxFeedback = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBoxAdmin
            // 
            this.cmbBoxAdmin.FormattingEnabled = true;
            this.cmbBoxAdmin.Location = new System.Drawing.Point(118, 55);
            this.cmbBoxAdmin.Name = "cmbBoxAdmin";
            this.cmbBoxAdmin.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxAdmin.TabIndex = 0;
            // 
            // rchTxtBoxFeedback
            // 
            this.rchTxtBoxFeedback.Location = new System.Drawing.Point(118, 120);
            this.rchTxtBoxFeedback.Name = "rchTxtBoxFeedback";
            this.rchTxtBoxFeedback.Size = new System.Drawing.Size(556, 160);
            this.rchTxtBoxFeedback.TabIndex = 1;
            this.rchTxtBoxFeedback.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(509, 307);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite.ForeColor = System.Drawing.SystemColors.Control;
            this.btnWrite.Location = new System.Drawing.Point(599, 307);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 31);
            this.btnWrite.TabIndex = 25;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // AdminFeedbackAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.rchTxtBoxFeedback);
            this.Controls.Add(this.cmbBoxAdmin);
            this.Name = "AdminFeedbackAdd";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.AdminFeedbackAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxAdmin;
        private System.Windows.Forms.RichTextBox rchTxtBoxFeedback;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnWrite;
    }
}
