using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectFinal
{
    public partial class DotsAndBoxes : Form
    {
        const int sizeOfGrid = 4;

        private Game game;
        private GameBot bot = new GameBot();

        private DifficultyAsk difficultyPrompt;

        public DotsAndBoxes()
        {
            InitializeComponent();
        }

        private void DotsAndBoxes_Load(object sender, EventArgs e)
        {
            resetGame();
            
            difficultyPrompt = new DifficultyAsk();
            difficultyPrompt.Show();
        }

        private void resetGame()
        {
            game = new Game(sizeOfGrid, sizeOfGrid, true); // Init the game's grid size.

            // Create the dots and boxes grid, programmatically.
            Panel lastPanel = new Panel();
            for (int row = 0; row < sizeOfGrid; row++)
                for (int column = 0; column < sizeOfGrid; column++)
                {
                    // Panel is required to be created because of how Radio Button's behave when they are in the same plane.
                    Panel panel = new Panel();
                    panel.Location = new Point(45 * (column + 1), 45 * (row + 1) + controlsPanel.Height);
                    panel.Size = new Size(13, 14);

                    RadioButton button = new RadioButton();
                    button.Text = "";
                    button.Location = new Point(0, -4);
                    button.Click += new EventHandler(radioButton_Click);

                    // Add these radio buttons to the game.
                    Dot dot = new Dot(button, panel.Location);
                    dot.row = row;
                    dot.column = column;
                    game.dots[row, column] = dot;

                    panel.Controls.Add(button);

                    Controls.Add(panel);

                    if (column == sizeOfGrid - 1 && row == sizeOfGrid - 1) // Is bottom right?
                        lastPanel = panel;

                }

            for (int row = 0; row < sizeOfGrid - 1; row++)
                for (int column = 0; column < sizeOfGrid - 1; column++)
                {
                    Label label = new Label();
                    label.Text = "";
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.AutoSize = false;

                    // These numbers are weird because the radiobuttons have strange dimensions.
                    Dot topLeft = game.dots[row, column];
                    label.Size = new Size(45 - 6, 45 - 6);
                    label.Location = new Point(topLeft.location.X + 9, topLeft.location.Y + 9);

                    Box box = new Box(label);
                    game.boxes[row, column] = box;

                    Controls.Add(label);
                }

            // Create unplayed paths.
            for (int row = 0; row < sizeOfGrid; row++)
                for (int column = 0; column < sizeOfGrid; column++)
                {
                    if (column != 0)
                    {
                        Path leftDotPath = new Path(game.dots[row, column - 1], game.dots[row, column], Game.PlayerTurn.none);
                        game.paths.Add(leftDotPath);

                        if (row != sizeOfGrid - 1)
                            game.boxes[row, column - 1].top = leftDotPath;
                        if (row != 0)
                            game.boxes[row - 1, column - 1].bottom = leftDotPath;
                    }

                    if (row != 0)
                    {
                        Path aboveDotPath = new Path(game.dots[row - 1, column], game.dots[row, column], Game.PlayerTurn.none);
                        game.paths.Add(aboveDotPath);

                        if (column != sizeOfGrid - 1)
                            game.boxes[row - 1, column].left = aboveDotPath;
                        if (column != 0)
                            game.boxes[row - 1, column - 1].right = aboveDotPath;
                    }
                }

            // Dynamically size the form based on the bottom right Panel that is placed on the form.
            Size = new Size(lastPanel.Location.X + lastPanel.Width + 45 + (45 / 3),
                            lastPanel.Location.Y + lastPanel.Height + (2 * 45));

            controlsPanel.Location = new Point((Size.Width / 2) - (controlsPanel.Size.Width / 2) - 6,
                                               controlsPanel.Location.Y);
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        private void radioButton_Click(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                game.handleClick(sender as RadioButton);
                postRadioClick();

                while (game.isPlayingComputer && game.currentTurn == Game.PlayerTurn.second)
                {
                    Path botPlay = bot.determineMove(game, difficultyPrompt.difficulty);
                    botPlay.setWhoPlayedPath(game.currentTurn);
                    
                    game.handleClick(botPlay.firstDot.button);
                    game.handleClick(botPlay.secondDot.button);
                    postRadioClick();

                    if (game.hasGameCompleted)
                        break;
                }
            }
        }

        private void postRadioClick()
        {
            Invalidate(); // Required to draw the lines.

            player1ScoreLabel.Text = string.Format("{0}", game.player1Score);
            player2ScoreLabel.Text = string.Format("{0}", game.player2Score);
        }

        private void DotsAndBoxes_Paint(object sender, PaintEventArgs e)
        {
            foreach (Path path in game.paths)
                path.drawLineFor(e);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            foreach (Dot dot in game.dots)
                Controls.Remove(dot.button);

            foreach (Control control in Controls)
                if (control is Panel && control != controlsPanel)
                    Controls.Remove(control);

            foreach (Box box in game.boxes)
                Controls.Remove(box.label);

            resetGame();
            player1ScoreLabel.Text = "0";
            player2ScoreLabel.Text = "0";

            Invalidate();
        }
    }
}
