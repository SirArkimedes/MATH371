namespace Project7
{
    partial class Barge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // inputDataGrid
            // 
            this.inputDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.weightColumn,
            this.costColumn});
            this.inputDataGrid.Location = new System.Drawing.Point(12, 80);
            this.inputDataGrid.Name = "inputDataGrid";
            this.inputDataGrid.Size = new System.Drawing.Size(236, 337);
            this.inputDataGrid.TabIndex = 0;
            this.inputDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.inputDataGrid_CellValidating);
            this.inputDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputDataGrid_CellValueChanged);
            this.inputDataGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputDataGrid_DefaultValuesNeeded);
            this.inputDataGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inputDataGrid_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input data";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(12, 25);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(236, 20);
            this.weightTextBox.TabIndex = 2;
            this.weightTextBox.Text = "10";
            this.weightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weightTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weight limit";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(91, 423);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 4;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // nameColumn
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameColumn.DefaultCellStyle = dataGridViewCellStyle25;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MaxInputLength = 10;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 55;
            // 
            // weightColumn
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.weightColumn.DefaultCellStyle = dataGridViewCellStyle26;
            this.weightColumn.HeaderText = "Weight";
            this.weightColumn.MaxInputLength = 10;
            this.weightColumn.Name = "weightColumn";
            this.weightColumn.Width = 60;
            // 
            // costColumn
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.costColumn.DefaultCellStyle = dataGridViewCellStyle27;
            this.costColumn.HeaderText = "Cost";
            this.costColumn.MaxInputLength = 10;
            this.costColumn.Name = "costColumn";
            this.costColumn.Width = 60;
            // 
            // Barge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 458);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Barge";
            this.ShowIcon = false;
            this.Text = "Barge problem (19.18)";
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inputDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costColumn;
    }
}