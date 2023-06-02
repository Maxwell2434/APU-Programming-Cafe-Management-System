namespace APU_Programming_Café_Management_System
{
    partial class AdminProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(333, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxName
            // 
            this.txtBoxName.BackColor = System.Drawing.Color.Silver;
            this.txtBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxName.Location = new System.Drawing.Point(336, 82);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(132, 22);
            this.txtBoxName.TabIndex = 1;
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.BackColor = System.Drawing.Color.Silver;
            this.txtBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxAddress.Location = new System.Drawing.Point(336, 133);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(132, 22);
            this.txtBoxAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(333, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.BackColor = System.Drawing.Color.Silver;
            this.txtBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxEmail.Location = new System.Drawing.Point(336, 241);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(132, 22);
            this.txtBoxEmail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(333, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.BackColor = System.Drawing.Color.Silver;
            this.txtBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxPhone.Location = new System.Drawing.Point(336, 190);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(132, 22);
            this.txtBoxPhone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(333, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(566, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AdminProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label1);
            this.Name = "AdminProfile";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.AdminProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
    }
}
