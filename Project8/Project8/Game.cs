using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project8
{
    class Dot
    {
        public RadioButton button { get; private set; }
        public Point point { get; private set; }

        public Dot(RadioButton button, Point point)
        {
            this.button = button;
            this.point = point;
        }
    }

    class Path
    {
        private Dot firstDot;
        private Dot secondDot;

        public bool hasDrawn = false;

        private Game.PlayerTurn playerWhoPlayedPath = Game.PlayerTurn.first;

        public Path(Dot first, Dot second, Game.PlayerTurn turn)
        {
            firstDot = first;
            secondDot = second;
            playerWhoPlayedPath = turn;
        }

        public void drawLineFor(PaintEventArgs e)
        {
            using (Pen p = pathPen())
            {
                e.Graphics.DrawLine(p,
                    new Point(firstDot.point.X + 6, firstDot.point.Y + 7),
                    new Point(secondDot.point.X + 6, secondDot.point.Y + 7));
            }

            hasDrawn = true;
        }

        private Pen pathPen()
        {
            Pen line = new Pen(Color.Black);
            if (playerWhoPlayedPath == Game.PlayerTurn.first)
                line = new Pen(Color.Orange);

            line.Width = 6;
            return line;
        }
    }

    class Box
    {

    }

    // Class that manages the Game's state.
    class Game
    {
        public enum PlayerTurn { first, second };

        private enum ClickState { none, inProgress };

        public Dot[,] dots;
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

            Tuple<int, int> coordinatesOfSender = dots.coordinatesOf(senderDot);
            int indexColumn = coordinatesOfSender.Item2;
            int indexRow = coordinatesOfSender.Item1;
            
            // Disable all Dots, except the up, down, left, and right.
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    if (row == indexRow - 1 && column == indexColumn || // Up
                        row == indexRow + 1 && column == indexColumn || // Down
                        row == indexRow && column == indexColumn - 1 || // Left
                        row == indexRow && column == indexColumn + 1 || // Right
                        row == indexRow && column == indexColumn) { } // Same Dot.
                    else
                        dots[row, column].button.Enabled = false;
        }

        private void handleSecondClick(Dot senderDot)
        {
            currentClickState = ClickState.none;

            currentClickedDot.button.Checked = false;
            senderDot.button.Checked = false;

            if (currentClickedDot != senderDot)
            {
                Path newPath = new Path(currentClickedDot, senderDot, currentTurn);
                paths.Add(newPath);
            }
            
            // Clear the disableds.
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    dots[row, column].button.Enabled = true;

            // Change who's turn it is.
            if (currentTurn == PlayerTurn.first) currentTurn = PlayerTurn.second;
            else currentTurn = PlayerTurn.first;
        }
    }
}
