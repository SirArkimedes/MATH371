using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project8
{
    public partial class DotsAndBoxes : Form
    {
        const uint sizeOfGrid = 9;

        public DotsAndBoxes()
        {
            InitializeComponent();
        }

        private void DotsAndBoxes_Load(object sender, EventArgs e)
        {
            // Create the dots and boxes grid, programmatically.
            Panel lastPanel = new Panel();
            for (int row = 0; row < sizeOfGrid; row++)
                for (int column = 0; column < sizeOfGrid; column++)
                {
                    // Panel is required to be created because of how Radio Button's behave when they are in the same plane.
                    Panel panel = new Panel();
                    panel.Location = new Point(45 * (row + 1), 45 * (column + 1));
                    panel.Size = new Size(20, 20);

                    RadioButton button = new RadioButton();
                    button.Text = "";
                    button.Location = new Point(0, 0);

                    panel.Controls.Add(button);

                    Controls.Add(panel);

                    if (column == sizeOfGrid - 1 && row == sizeOfGrid - 1)
                        lastPanel = panel;

                }

            Size = new Size(lastPanel.Location.X + lastPanel.Width + 45 + (45/3),
                            lastPanel.Location.Y + lastPanel.Height + (2 * 45));
        }
    }
}
