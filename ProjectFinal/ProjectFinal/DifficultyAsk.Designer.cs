namespace ProjectFinal
{
    partial class DifficultyAsk
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
            this.easyButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.insaneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.Lime;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.ForeColor = System.Drawing.Color.White;
            this.easyButton.Location = new System.Drawing.Point(12, 12);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(212, 67);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.BackColor = System.Drawing.Color.Orange;
            this.mediumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediumButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumButton.ForeColor = System.Drawing.Color.White;
            this.mediumButton.Location = new System.Drawing.Point(12, 97);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(212, 67);
            this.mediumButton.TabIndex = 1;
            this.mediumButton.Text = "Medium";
            this.mediumButton.UseVisualStyleBackColor = false;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // insaneButton
            // 
            this.insaneButton.BackColor = System.Drawing.Color.Red;
            this.insaneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insaneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insaneButton.ForeColor = System.Drawing.Color.White;
            this.insaneButton.Location = new System.Drawing.Point(12, 182);
            this.insaneButton.Name = "insaneButton";
            this.insaneButton.Size = new System.Drawing.Size(212, 67);
            this.insaneButton.TabIndex = 2;
            this.insaneButton.Text = "Insane";
            this.insaneButton.UseVisualStyleBackColor = false;
            this.insaneButton.Click += new System.EventHandler(this.insaneButton_Click);
            // 
            // DifficultyAsk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 261);
            this.Controls.Add(this.insaneButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DifficultyAsk";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Difficulty";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button insaneButton;
    }
}