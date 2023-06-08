namespace APU_Programming_Café_Management_System.AdminForm
{
    partial class TrainerFeedback
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
            this.btnRead = new System.Windows.Forms.Button();
            this.lstViewTrainer = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRead.Location = new System.Drawing.Point(598, 301);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 31);
            this.btnRead.TabIndex = 30;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lstViewTrainer
            // 
            this.lstViewTrainer.HideSelection = false;
            this.lstViewTrainer.Location = new System.Drawing.Point(127, 74);
            this.lstViewTrainer.Name = "lstViewTrainer";
            this.lstViewTrainer.Size = new System.Drawing.Size(546, 199);
            this.lstViewTrainer.TabIndex = 28;
            this.lstViewTrainer.UseCompatibleStateImageBehavior = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(127, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(202, 25);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Feedback by Trainers";
            // 
            // TrainerFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lstViewTrainer);
            this.Name = "TrainerFeedback";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.TrainerFeedback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ListView lstViewTrainer;
        private System.Windows.Forms.Label lblTitle;
    }
}
