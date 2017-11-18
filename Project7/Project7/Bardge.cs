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

        List<string> alphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I",
                                "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
                                "W", "X", "Y", "Z", "ZZZZ" };

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
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        private void inputDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = getAlphabetValue(e.Row.Index);
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
