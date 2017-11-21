namespace Project7
{
    partial class StochasticForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputDataGrid = new System.Windows.Forms.DataGridView();
            this.locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilityFirstColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilitySecondColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilityThirdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // inputDataGrid
            // 
            this.inputDataGrid.AllowUserToResizeColumns = false;
            this.inputDataGrid.AllowUserToResizeRows = false;
            this.inputDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.locationColumn,
            this.probabilityFirstColumn,
            this.probabilitySecondColumn,
            this.probabilityThirdColumn});
            this.inputDataGrid.Location = new System.Drawing.Point(12, 41);
            this.inputDataGrid.Name = "inputDataGrid";
            this.inputDataGrid.Size = new System.Drawing.Size(560, 300);
            this.inputDataGrid.TabIndex = 0;
            this.inputDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.inputDataGrid_CellValidating);
            this.inputDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputDataGrid_CellValueChanged);
            this.inputDataGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputDataGrid_DefaultValuesNeeded);
            this.inputDataGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inputDataGrid_RowsRemoved);
            // 
            // locationColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.locationColumn.HeaderText = "";
            this.locationColumn.Name = "locationColumn";
            this.locationColumn.ReadOnly = true;
            this.locationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.locationColumn.Width = 60;
            // 
            // probabilityFirstColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilityFirstColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.probabilityFirstColumn.HeaderText = "Component 1";
            this.probabilityFirstColumn.MaxInputLength = 15;
            this.probabilityFirstColumn.Name = "probabilityFirstColumn";
            this.probabilityFirstColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilityFirstColumn.Width = 80;
            // 
            // probabilitySecondColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilitySecondColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.probabilitySecondColumn.HeaderText = "Component 2";
            this.probabilitySecondColumn.MaxInputLength = 15;
            this.probabilitySecondColumn.Name = "probabilitySecondColumn";
            this.probabilitySecondColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilitySecondColumn.Width = 80;
            // 
            // probabilityThirdColumn
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilityThirdColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.probabilityThirdColumn.HeaderText = "Component 3";
            this.probabilityThirdColumn.MaxInputLength = 15;
            this.probabilityThirdColumn.Name = "probabilityThirdColumn";
            this.probabilityThirdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilityThirdColumn.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Data";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(248, 347);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 2;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Component";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Remove Component";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.removeColumnButton_Click);
            // 
            // StochasticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 382);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDataGrid);
            this.MaximizeBox = false;
            this.Name = "StochasticForm";
            this.ShowIcon = false;
            this.Text = "Stochastic problem (19.36)";
            this.Load += new System.EventHandler(this.StochasticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inputDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn probabilityFirstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn probabilitySecondColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn probabilityThirdColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}