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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilityFirstColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilitySecondColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probabilityThirdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.inputDataGrid.Location = new System.Drawing.Point(12, 25);
            this.inputDataGrid.Name = "inputDataGrid";
            this.inputDataGrid.Size = new System.Drawing.Size(498, 274);
            this.inputDataGrid.TabIndex = 0;
            this.inputDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.inputDataGrid_CellValidating);
            this.inputDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputDataGrid_CellValueChanged);
            this.inputDataGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputDataGrid_DefaultValuesNeeded);
            this.inputDataGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inputDataGrid_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Data";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(225, 305);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 2;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // locationColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.locationColumn.HeaderText = "";
            this.locationColumn.Name = "locationColumn";
            this.locationColumn.ReadOnly = true;
            this.locationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.locationColumn.Width = 60;
            // 
            // probabilityFirstColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilityFirstColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.probabilityFirstColumn.HeaderText = "Component 1";
            this.probabilityFirstColumn.MaxInputLength = 15;
            this.probabilityFirstColumn.Name = "probabilityFirstColumn";
            this.probabilityFirstColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilityFirstColumn.Width = 80;
            // 
            // probabilitySecondColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilitySecondColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.probabilitySecondColumn.HeaderText = "Component 2";
            this.probabilitySecondColumn.MaxInputLength = 15;
            this.probabilitySecondColumn.Name = "probabilitySecondColumn";
            this.probabilitySecondColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilitySecondColumn.Width = 80;
            // 
            // probabilityThirdColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.probabilityThirdColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.probabilityThirdColumn.HeaderText = "Component 3";
            this.probabilityThirdColumn.MaxInputLength = 15;
            this.probabilityThirdColumn.Name = "probabilityThirdColumn";
            this.probabilityThirdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.probabilityThirdColumn.Width = 80;
            // 
            // StochasticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 340);
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
    }
}