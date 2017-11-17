namespace Project7
{
  partial class QuestionForm
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
            this.firstButton = new System.Windows.Forms.Button();
            this.secondButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(12, 12);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(153, 53);
            this.firstButton.TabIndex = 0;
            this.firstButton.Text = "Barge problem (19.18)";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // secondButton
            // 
            this.secondButton.Location = new System.Drawing.Point(175, 12);
            this.secondButton.Name = "secondButton";
            this.secondButton.Size = new System.Drawing.Size(153, 53);
            this.secondButton.TabIndex = 1;
            this.secondButton.Text = "Probability problem (19.36)";
            this.secondButton.UseVisualStyleBackColor = true;
            this.secondButton.Click += new System.EventHandler(this.secondButton_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 77);
            this.Controls.Add(this.secondButton);
            this.Controls.Add(this.firstButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "QuestionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Which type do you wish to solve?";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button firstButton;
    private System.Windows.Forms.Button secondButton;
  }
}

