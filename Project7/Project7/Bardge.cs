using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project7
{
    public partial class Bardge : Form
    {

        private List<string> alphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I",
                                        "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
                                        "W", "X", "Y", "Z", "ZZZZ" };

        private BardgeSolver solver = new BardgeSolver();

        /***********************/
        /* Init                */
        /***********************/

        public Bardge()
        {
            InitializeComponent();

            // Add some default data.
            inputDataGrid.Rows.Add("A", 1, 10);
            inputDataGrid.Rows.Add("B", 2, 25);
            inputDataGrid.Rows.Add("C", 3, 40);
            inputDataGrid.Rows.Add("D", 4, 60);

            solver.items.Add(new Item("A", 1, 10));
            solver.items.Add(new Item("B", 2, 25));
            solver.items.Add(new Item("C", 3, 40));
            solver.items.Add(new Item("D", 4, 60));
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

            if (headerText == "Cost")
                if (!double.TryParse(e.FormattedValue.ToString(), out double value))
                {
                    MessageBox.Show("Cost must be convertible to a double!");
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
                double weight = 0.0;
                double cost = 0.0;

                double.TryParse((row.Cells[1].Value ?? "0.0").ToString(), out weight);
                double.TryParse((row.Cells[2].Value ?? "0.0").ToString(), out cost);

                Item item = new Item(name, weight, cost);
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

        /***********************/
        /* Helpers             */
        /***********************/

        private string getAlphabetValue(int index)
        {
            string value = "";
            if (index < alphabet.Count)
                value = alphabet[index];
            else
                value = alphabet[alphabet.Count - 1];

            return value;
        }
    }
}
