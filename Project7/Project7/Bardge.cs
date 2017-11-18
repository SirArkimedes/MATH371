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
        public Bardge()
        {
            InitializeComponent();

            // Add some default data.
            inputDataGrid.Rows.Add("1", 1, 10);
            inputDataGrid.Rows.Add("2", 2, 25);
            inputDataGrid.Rows.Add("3", 3, 40);
            inputDataGrid.Rows.Add("4", 4, 60);
        }
    }
}
