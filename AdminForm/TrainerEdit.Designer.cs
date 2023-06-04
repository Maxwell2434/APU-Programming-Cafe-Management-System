namespace APU_Programming_Café_Management_System.AdminForm
{
    partial class TrainerEdit
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
            this.lstViewTrainer = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewTrainer
            // 
            this.lstViewTrainer.HideSelection = false;
            this.lstViewTrainer.Location = new System.Drawing.Point(128, 94);
            this.lstViewTrainer.Name = "lstViewTrainer";
            this.lstViewTrainer.Size = new System.Drawing.Size(546, 199);
            this.lstViewTrainer.TabIndex = 5;
            this.lstViewTrainer.UseCompatibleStateImageBehavior = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(509, 321);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Location = new System.Drawing.Point(591, 40);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 31);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Location = new System.Drawing.Point(599, 321);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // TrainerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstViewTrainer);
            this.Name = "TrainerEdit";
            this.Size = new System.Drawing.Size(800, 406);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewTrainer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
    }
}
