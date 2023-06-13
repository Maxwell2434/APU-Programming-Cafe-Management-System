namespace APU_Programming_Café_Management_System.StudentForm
{
    partial class StudentSchedule
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
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnThursday = new System.Windows.Forms.Button();
            this.btnWednesday = new System.Windows.Forms.Button();
            this.btnSaturday = new System.Windows.Forms.Button();
            this.btnSunday = new System.Windows.Forms.Button();
            this.lstView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnFriday
            // 
            this.btnFriday.FlatAppearance.BorderSize = 0;
            this.btnFriday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFriday.Location = new System.Drawing.Point(455, 40);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(75, 50);
            this.btnFriday.TabIndex = 5;
            this.btnFriday.Text = "Friday";
            this.btnFriday.UseVisualStyleBackColor = true;
            this.btnFriday.Click += new System.EventHandler(this.btnFriday_Click);
            // 
            // btnMonday
            // 
            this.btnMonday.FlatAppearance.BorderSize = 0;
            this.btnMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonday.Location = new System.Drawing.Point(69, 40);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(80, 50);
            this.btnMonday.TabIndex = 6;
            this.btnMonday.Text = "Monday";
            this.btnMonday.UseVisualStyleBackColor = true;
            this.btnMonday.Click += new System.EventHandler(this.btnMonday_Click);
            // 
            // btnTuesday
            // 
            this.btnTuesday.FlatAppearance.BorderSize = 0;
            this.btnTuesday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuesday.Location = new System.Drawing.Point(155, 40);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(91, 50);
            this.btnTuesday.TabIndex = 7;
            this.btnTuesday.Text = "Tuesday";
            this.btnTuesday.UseVisualStyleBackColor = true;
            this.btnTuesday.Click += new System.EventHandler(this.btnTuesday_Click);
            // 
            // btnThursday
            // 
            this.btnThursday.FlatAppearance.BorderSize = 0;
            this.btnThursday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThursday.Location = new System.Drawing.Point(363, 40);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(86, 50);
            this.btnThursday.TabIndex = 9;
            this.btnThursday.Text = "Thursday";
            this.btnThursday.UseVisualStyleBackColor = true;
            this.btnThursday.Click += new System.EventHandler(this.btnThursday_Click);
            // 
            // btnWednesday
            // 
            this.btnWednesday.FlatAppearance.BorderSize = 0;
            this.btnWednesday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWednesday.Location = new System.Drawing.Point(252, 40);
            this.btnWednesday.Name = "btnWednesday";
            this.btnWednesday.Size = new System.Drawing.Size(105, 50);
            this.btnWednesday.TabIndex = 8;
            this.btnWednesday.Text = "Wednesday";
            this.btnWednesday.UseVisualStyleBackColor = true;
            this.btnWednesday.Click += new System.EventHandler(this.btnWednesday_Click);
            // 
            // btnSaturday
            // 
            this.btnSaturday.FlatAppearance.BorderSize = 0;
            this.btnSaturday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaturday.Location = new System.Drawing.Point(536, 40);
            this.btnSaturday.Name = "btnSaturday";
            this.btnSaturday.Size = new System.Drawing.Size(84, 50);
            this.btnSaturday.TabIndex = 10;
            this.btnSaturday.Text = "Saturday";
            this.btnSaturday.UseVisualStyleBackColor = true;
            this.btnSaturday.Click += new System.EventHandler(this.btnSaturday_Click);
            // 
            // btnSunday
            // 
            this.btnSunday.FlatAppearance.BorderSize = 0;
            this.btnSunday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSunday.Location = new System.Drawing.Point(626, 40);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(77, 50);
            this.btnSunday.TabIndex = 11;
            this.btnSunday.Text = "Sunday";
            this.btnSunday.UseVisualStyleBackColor = true;
            this.btnSunday.Click += new System.EventHandler(this.btnSunday_Click);
            // 
            // lstView
            // 
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(92, 110);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(586, 199);
            this.lstView.TabIndex = 52;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // StudentSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.btnSunday);
            this.Controls.Add(this.btnSaturday);
            this.Controls.Add(this.btnMonday);
            this.Controls.Add(this.btnFriday);
            this.Controls.Add(this.btnTuesday);
            this.Controls.Add(this.btnThursday);
            this.Controls.Add(this.btnWednesday);
            this.Name = "StudentSchedule";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.StudentSchedule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Button btnWednesday;
        private System.Windows.Forms.Button btnSaturday;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.ListView lstView;
    }
}
