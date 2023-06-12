namespace APU_Programming_Café_Management_System.LecturerForm
{
    partial class LecturerRequests
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
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstView
            // 
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(127, 104);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(546, 199);
            this.lstView.TabIndex = 46;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(122, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 25);
            this.lblTitle.TabIndex = 48;
            this.lblTitle.Text = "Student Requests";
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReject.Location = new System.Drawing.Point(497, 330);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 31);
            this.btnReject.TabIndex = 50;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnApprove.Location = new System.Drawing.Point(589, 330);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(84, 31);
            this.btnApprove.TabIndex = 49;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // LecturerRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstView);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "LecturerRequests";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.LecturerRequests_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
    }
}
