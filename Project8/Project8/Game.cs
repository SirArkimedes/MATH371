using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project8
{
    class Dot
    {
        public RadioButton button { get; private set; }
        public Point location { get; private set; }

        public int row = -1;
        public int column = -1;

        public Dot(RadioButton button, Point point)
        {
            this.button = button;
            this.location = point;
        }
    }

    class Path
    {
        private Dot firstDot;
        private Dot secondDot;

        public Game.PlayerTurn playerWhoPlayedPath { get; private set; }

        public Path(Dot first, Dot second, Game.PlayerTurn turn)
        {
            firstDot = first;
            secondDot = second;
            playerWhoPlayedPath = turn;
        }

        public void drawLineFor(PaintEventArgs e)
        {
            // This is required for draw. Not sure why...
            using (Pen p = pathPen())
            {
                e.Graphics.DrawLine(p,
                    new Point(firstDot.location.X + 6, firstDot.location.Y + 7),
                    new Point(secondDot.location.X + 6, secondDot.location.Y + 7));
            }
        }

        private Pen pathPen()
        {
            Pen line = new Pen(Game.player2Color);
            if (playerWhoPlayedPath == Game.PlayerTurn.first)
                line = new Pen(Game.player1Color);

            line.Width = 6;
            return line;
        }
    }

    class Box
    {
        private Label label;

        public Path top;
        public Path bottom;
        public Path left;
        public Path right;

        public Box() { }

        public Box(Label label)
        {
            this.label = label;
        }

        public bool checkForCompletedWithLastPath(Path path)
        {
            if (top != null && bottom != null && left != null && right != null)
            {
                if (path.playerWhoPlayedPath == Game.PlayerTurn.first)
                    label.BackColor = Game.player1Color;
                else
                    label.BackColor = Game.player2Color;

                return true;
            }

            return false;
        }
    }

    // Class that manages the Game's state.
    class Game
    {
        public static Color player1Color = Color.LightSkyBlue;
        public static Color player2Color = Color.Firebrick;

        public enum PlayerTurn { first, second };

        private enum ClickState { none, inProgress };

        public Dot[,] dots;
        public Box[,] boxes;
        public List<Path> paths = new List<Path>();

        private uint width = 0;
        private uint height = 0;

        private ClickState currentClickState = ClickState.none;
        private Dot currentClickedDot;

        public PlayerTurn currentTurn { get; private set; }

        /***********************/
        /* Init                */
        /***********************/

        public Game(uint width, uint height)
        {
            dots = new Dot[width, height];
            boxes = new Box[width - 1, height - 1];

            this.width = width;
            this.height = height;

            currentTurn = PlayerTurn.first;
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        public void handleClick(RadioButton button)
        {
            Dot senderDot = findDotForRadioButton(button);

            if (senderDot != null) // Just making sure we found the Dot.
                if (currentClickState == ClickState.none)
                    handleFirstClick(senderDot);
                else
                    handleSecondClick(senderDot);
        }

        /***********************/
        /* Helpers             */
        /***********************/

        private Dot findDotForRadioButton(RadioButton button)
        {
            Dot senderDot = null;
            foreach (Dot dot in dots)
                if (dot.button == button)
                {
                    senderDot = dot;
                    break;
                }

            return senderDot;
        }

        private void handleFirstClick(Dot senderDot)
        {
            currentClickState = ClickState.inProgress;
            currentClickedDot = senderDot;

            int indexRow = senderDot.row;
            int indexColumn = senderDot.column;

            // Disable all Dots, except the up, down, left, and right.
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    if ((row == indexRow - 1 && column == indexColumn) || // Up
                        (row == indexRow + 1 && column == indexColumn) || // Down
                        (row == indexRow && column == indexColumn - 1) || // Left
                        (row == indexRow && column == indexColumn + 1) || // Right
                        (row == indexRow && column == indexColumn)) { } // Same Dot.
                    else
                        dots[row, column].button.Enabled = false;
        }

        private void handleSecondClick(Dot senderDot)
        {
            currentClickState = ClickState.none;

            currentClickedDot.button.Checked = false;
            senderDot.button.Checked = false;

            bool completedBoxWithPath = false; // Keep track of if the turn is the same.

            if (currentClickedDot != senderDot)
            {
                Path newPath = new Path(currentClickedDot, senderDot, currentTurn);
                paths.Add(newPath);
                // Add this new path to a Box.
                if (currentClickedDot.location.Y == senderDot.location.Y) // This is a horizontal path.
                {
                    int indexRow = senderDot.row; // Assume senderDot is left most dot.
                    int indexColumn = senderDot.column; // Assume senderDot is left most dot.

                    if (currentClickedDot.location.X < senderDot.location.X) // currentClicked is the left most dot.
                    {
                        indexRow = currentClickedDot.row;
                        indexColumn = currentClickedDot.column;
                    }

                    Box bottomBox = new Box();
                    if (indexRow != height - 1)
                        bottomBox = boxes[indexRow, indexColumn];

                    Box topBox = new Box();
                    if (indexRow != 0)
                        topBox = boxes[indexRow - 1, indexColumn];

                    bottomBox.top = newPath;
                    topBox.bottom = newPath;

                    completedBoxWithPath = bottomBox.checkForCompletedWithLastPath(newPath);
                    if (!completedBoxWithPath) completedBoxWithPath = topBox.checkForCompletedWithLastPath(newPath);
                    else topBox.checkForCompletedWithLastPath(newPath);
                }
                else // This is a vertical path.
                {
                    int indexRow = senderDot.row; // Assume senderDot is top most dot.
                    int indexColumn = senderDot.column; // Assume senderDot is top most dot.

                    if (currentClickedDot.location.Y < senderDot.location.Y) // currentClicked is the top most dot.
                    {
                        indexRow = currentClickedDot.row;
                        indexColumn = currentClickedDot.column;
                    }

                    Box rightBox = new Box();
                    if (indexColumn != width - 1)
                        rightBox = boxes[indexRow, indexColumn];

                    Box leftBox = new Box();
                    if (indexColumn != 0)
                        leftBox = boxes[indexRow, indexColumn - 1];

                    rightBox.left = newPath;
                    leftBox.right = newPath;

                    completedBoxWithPath = rightBox.checkForCompletedWithLastPath(newPath);
                    if (!completedBoxWithPath) completedBoxWithPath = leftBox.checkForCompletedWithLastPath(newPath);
                    else leftBox.checkForCompletedWithLastPath(newPath);
                }

                // Change who's turn it is.
                if (!completedBoxWithPath)
                    if (currentTurn == PlayerTurn.first) currentTurn = PlayerTurn.second;
                    else currentTurn = PlayerTurn.first;
            }
            
            // Clear the disabled buttons.
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    dots[row, column].button.Enabled = true;
        }
    }
}
