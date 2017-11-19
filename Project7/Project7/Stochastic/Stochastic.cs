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
    public partial class StochasticForm : Form
    {
        public StochasticForm()
        {
            InitializeComponent();
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        private void StochasticForm_Load(object sender, EventArgs e)
        {
            inputDataGrid.Rows.Add("Job 1", 0.83, 0.92, 0.91);
            inputDataGrid.Rows.Add("Job 2", 0.83, 0.92, 0.91);
            inputDataGrid.Rows.Add("Job 3", 0.83, 0.92, 0.91);
        }

        private void inputDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("Job {0}", e.Row.Index + 1);
        }

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

        private void inputDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Do Stuff with the array.

            /*
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
            */
        }

        private void inputDataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Delete from the array.
            //solver.items.RemoveAt(e.RowIndex);
        }
    }
}
