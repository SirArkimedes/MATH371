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
      this.firstButton.Location = new System.Drawing.Point(79, 39);
      this.firstButton.Name = "firstButton";
      this.firstButton.Size = new System.Drawing.Size(153, 53);
      this.firstButton.TabIndex = 0;
      this.firstButton.Text = "Barge problem";
      this.firstButton.UseVisualStyleBackColor = true;
      this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
      // 
      // secondButton
      // 
      this.secondButton.Location = new System.Drawing.Point(79, 143);
      this.secondButton.Name = "secondButton";
      this.secondButton.Size = new System.Drawing.Size(153, 53);
      this.secondButton.TabIndex = 1;
      this.secondButton.Text = "The other one";
      this.secondButton.UseVisualStyleBackColor = true;
      this.secondButton.Click += new System.EventHandler(this.secondButton_Click);
      // 
      // QuestionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(318, 243);
      this.Controls.Add(this.secondButton);
      this.Controls.Add(this.firstButton);
      this.Name = "QuestionForm";
      this.Text = "Which do you wish to solve?";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button firstButton;
    private System.Windows.Forms.Button secondButton;
  }
}

