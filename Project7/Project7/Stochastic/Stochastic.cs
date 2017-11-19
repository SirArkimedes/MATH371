using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project7
{
    public partial class StochasticForm : Form
    {

        private StochasticSolver solver = new StochasticSolver();

        public StochasticForm()
        {
            InitializeComponent();
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        // Create defaults on load.
        private void StochasticForm_Load(object sender, EventArgs e)
        {
            inputDataGrid.Rows.Add("Job 1", 0.83, 0.92, 0.91);
            inputDataGrid.Rows.Add("Job 2", 0.89, 0.83, 0.85);
            inputDataGrid.Rows.Add("Job 3", 0.91, 0.93, 0.93);

            solver.contractors.Add(new Contractor("Job 1", new List<double> { 0.83, 0.92, 0.91 }));
            solver.contractors.Add(new Contractor("Job 2", new List<double> { 0.89, 0.83, 0.85 }));
            solver.contractors.Add(new Contractor("Job 3", new List<double> { 0.91, 0.93, 0.93 }));
        }

        // Data grid \\

        // Default value for Job # on read only cell.
        private void inputDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("Job {0}", e.Row.Index + 1);
        }

        // Cell validation.
        private void inputDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null || e.FormattedValue.ToString() == "") return;

            string headerText = inputDataGrid.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Contains("Component"))
                if (!double.TryParse(e.FormattedValue.ToString(), out double value) || value < 0.0 || value > 1.0)
                {
                    MessageBox.Show("Value must be a double between 0 and 1!");
                    e.Cancel = true;
                }
        }

        // Cell value changes.
        private void inputDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = inputDataGrid.Rows[e.RowIndex];

                string name = row.Cells[0].Value.ToString();

                // Probabilities in column configuration.
                List<double> probabilities = new List<double>();
                for (int i = 1; i < inputDataGrid.ColumnCount; i++)
                {
                    double.TryParse((row.Cells[i].Value ?? "0.0").ToString(), out double prob);
                    probabilities.Add(prob);
                }

                if (solver.contractors.Count == e.RowIndex)
                {
                    // Create a new contractor.
                    Contractor contracter = new Contractor(name, probabilities);
                    solver.contractors.Add(contracter);
                }
                else
                    // Update the old contractor's values.
                    solver.contractors[e.RowIndex].probabilities = probabilities;
            }
        }

        private void inputDataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            solver.contractors.RemoveAt(e.RowIndex);
        }

        // Solve button \\

        private void solveButton_Click(object sender, EventArgs e)
        {
            // Clear the color from the cells.
            foreach (DataGridViewRow row in inputDataGrid.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (!cell.ReadOnly)
                        cell.Style.BackColor = Color.White;

            Tuple<List<int>, double> result = solver.solve();
            for (int i = 0; i < result.Item1.Count; i++)
            {
                if (result.Item1[i] >= 0)
                    inputDataGrid.Rows[result.Item1[i]].Cells[i + 1].Style.BackColor = Color.LightYellow;
            }
        }
    }
}
