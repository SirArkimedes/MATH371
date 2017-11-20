using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project7
{
    public partial class BargeForm : Form
    {

        private List<string> alphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I",
                                        "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
                                        "W", "X", "Y", "Z", "ZZZZ" };

        private BargeSolver solver = new BargeSolver();

        /***********************/
        /* Init                */
        /***********************/

        public BargeForm()
        {
            InitializeComponent();

            // Add problem default data.
            inputDataGrid.Rows.Add("A", 1, 10);
            inputDataGrid.Rows.Add("B", 2, 25);
            inputDataGrid.Rows.Add("C", 3, 45);
            inputDataGrid.Rows.Add("D", 4, 60);

            solver.items.Add(new Item("A", 1, 10));
            solver.items.Add(new Item("B", 2, 25));
            solver.items.Add(new Item("C", 3, 45));
            solver.items.Add(new Item("D", 4, 60));

            solver.weightLimit = 10;
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        // Assign the default name for the cell.
        private void inputDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = getAlphabetValue(e.Row.Index);
        }

        // Validate that what is entered into the cell is okay for use.
        private void inputDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null || e.FormattedValue.ToString() == "") return;

            string headerText = inputDataGrid.Columns[e.ColumnIndex].HeaderText;

            if (headerText == "Profit")
                if (!double.TryParse(e.FormattedValue.ToString(), out double value))
                {
                    MessageBox.Show("Profit must be convertible to a double!");
                    e.Cancel = true;
                }

            if (headerText == "Weight")
                if (!double.TryParse(e.FormattedValue.ToString(), out double value2))
                {
                    MessageBox.Show("Weight must be convertible to a double!");
                    e.Cancel = true;
                }
        }

        // Update the array of items according to the cell changes of the input data grid.
        private void inputDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = inputDataGrid.Rows[e.RowIndex];

                string name = row.Cells[0].Value.ToString();

                int.TryParse((row.Cells[1].Value ?? "0.0").ToString(), out int weight);
                double.TryParse((row.Cells[2].Value ?? "0.0").ToString(), out double profit);

                Item item = new Item(name, weight, profit);
                if (solver.items.Count == e.RowIndex)
                    solver.items.Add(item);
                else
                    solver.items[e.RowIndex] = item;
            }
        }

        // Remove the item at the index of the row that was removed.
        private void inputDataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            solver.items.RemoveAt(e.RowIndex);
        }

        // Solve button \\

        private void solveButton_Click(object sender, EventArgs e)
        {
            outputDataGrid.Rows.Clear();

            solver.weightLimit = int.Parse(weightUpDown.Text);
            ProfitTestState maxState = solver.solve();

            // Display maxState
            foreach (Item item in maxState.subItems)
                outputDataGrid.Rows.Add(item.name, item.profit);
            outputDataGrid.Rows.Add();
            outputDataGrid.Rows.Add("Total:", maxState.overallProfit);
        }

        /***********************/
        /* Helpers             */
        /***********************/

        private string getAlphabetValue(int index)
        {
            // Return A, B, C, ... if within range, otherwise return ZZZZ.
            string value = "";
            if (index < alphabet.Count)
                value = alphabet[index];
            else
                value = alphabet[alphabet.Count - 1];

            return value;
        }
    }
}
