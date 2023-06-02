namespace APU_Programming_Café_Management_System
{
    partial class AdminHomePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(713, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 23);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // AdminHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProfile);
            this.Name = "AdminHomePage";
            this.Text = "AdminHomePage";
            this.Load += new System.EventHandler(this.AdminHomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
    }
}