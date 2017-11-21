using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project8
{
    public partial class DotsAndBoxes : Form
    {
        const uint sizeOfGrid = 5;

        private Game game;

        public DotsAndBoxes()
        {
            InitializeComponent();
        }

        private void DotsAndBoxes_Load(object sender, EventArgs e)
        {
            game = new Game(sizeOfGrid, sizeOfGrid); // Init the game's grid size.

            // Create the dots and boxes grid, programmatically.
            Panel lastPanel = new Panel();
            for (int row = 0; row < sizeOfGrid; row++)
                for (int column = 0; column < sizeOfGrid; column++)
                {
                    // Panel is required to be created because of how Radio Button's behave when they are in the same plane.
                    Panel panel = new Panel();
                    panel.Location = new Point(45 * (row + 1), 45 * (column + 1));
                    panel.Size = new Size(13, 14);

                    RadioButton button = new RadioButton();
                    button.Text = "";
                    button.Location = new Point(0, -4);
                    button.Click += new EventHandler(radioButton_Click);

                    // Add these radio buttons to the game.
                    Dot dot = new Dot(button, panel.Location);
                    game.dots[row, column] = dot;

                    panel.Controls.Add(button);

                    Controls.Add(panel);

                    if (column == sizeOfGrid - 1 && row == sizeOfGrid - 1) // Is bottom right?
                        lastPanel = panel;

                }

            // Dynamically size the form based on the bottom right Panel that is placed on the form.
            Size = new Size(lastPanel.Location.X + lastPanel.Width + 45 + (45/3),
                            lastPanel.Location.Y + lastPanel.Height + (2 * 45));
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        private void radioButton_Click(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                game.handleClick(sender as RadioButton);
                if (game.paths.Count > 0)
                    Invalidate();
            }
        }

        private void DotsAndBoxes_Paint(object sender, PaintEventArgs e)
        {
            if (game.paths.Count > 0)
                foreach (Path path in game.paths)
                    path.drawLineFor(e);
        }
    }
}
