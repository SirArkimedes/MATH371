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
        public Dot firstDot { get; private set; }
        public Dot secondDot { get; private set; }

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
        public Label label { get; private set; }

        public Path top;
        public Path bottom;
        public Path left;
        public Path right;

        public bool hasBeenClaimed
        {
            get
            {
                if (top != null && bottom != null && left != null && right != null)
                    return true;
                else
                    return false;
            }
        }

        public Box() { }

        public Box(Label label)
        {
            this.label = label;
        }

        public bool checkForCompletedWithLastPath(Path path)
        {
            if (hasBeenClaimed)
            {
                setClaimedWithLastPath(path);
                return true;
            }
            else return false;
        }

        private void setClaimedWithLastPath(Path path)
        {
            if (path.playerWhoPlayedPath == Game.PlayerTurn.first)
            {
                label.Text = "You";
                label.BackColor = Game.player1Color;
            }
            else
            {
                label.Text = "AI";
                label.BackColor = Game.player2Color;
            }
        }
    }

    // Class that manages the Game's state.
    class Game
    {
        public static Color player1Color = Color.LightSkyBlue;
        public static Color player2Color = Color.LightGreen;

        public enum PlayerTurn { first, second };

        private enum ClickState { none, inProgress };

        public Dot[,] dots;
        public Box[,] boxes;
        public List<Path> paths = new List<Path>();

        public int width { get; private set; }
        public int height { get; private set; }

        private ClickState currentClickState = ClickState.none;
        private Dot currentClickedDot;

        public PlayerTurn currentTurn { get; private set; }
        public uint player1Score { get; private set; }
        public uint player2Score { get; private set; }

        public bool isPlayingComputer { get; private set; }

        public bool hasGameCompleted { get; private set; }

        /***********************/
        /* Init                */
        /***********************/

        public Game(int width, int height, bool isPlayingComputer)
        {
            dots = new Dot[width, height];
            boxes = new Box[width - 1, height - 1];

            if (width < 2 || height < 2)
                throw new Exception();

            this.width = width;
            this.height = height;

            currentTurn = PlayerTurn.first;
            player1Score = 0;
            player2Score = 0;

            hasGameCompleted = false;

            this.isPlayingComputer = isPlayingComputer;
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

        private void handleFirstClick(Dot senderDot)
        {
            currentClickState = ClickState.inProgress;
            currentClickedDot = senderDot;

            int indexRow = senderDot.row;
            int indexColumn = senderDot.column;

            // Disable all Dots, except the up, down, left, and right.
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                {
                    Dot dot = dots[row, column];
                    if ((row == indexRow - 1 && column == indexColumn) || // Up
                        (row == indexRow + 1 && column == indexColumn) || // Down
                        (row == indexRow && column == indexColumn - 1) || // Left
                        (row == indexRow && column == indexColumn + 1) || // Right
                        (row == indexRow && column == indexColumn))
                    {
                        if (isDotAtMaxPaths(dot) || doesPathExistBetweenDot(dot, senderDot)) dot.button.Enabled = false;
                    }
                    else
                        dot.button.Enabled = false;
                }
        }

        private void handleSecondClick(Dot senderDot)
        {
            currentClickState = ClickState.none;

            currentClickedDot.button.Checked = false;
            senderDot.button.Checked = false;

            if (currentClickedDot != senderDot)
            {
                bool completedBoxWithPath = false; // Keep track of if the turn is the same.

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

                    bool bottomBoxAwarded = bottomBox.checkForCompletedWithLastPath(newPath);
                    bool topBoxAwarded = topBox.checkForCompletedWithLastPath(newPath);

                    if (bottomBoxAwarded)
                    { if (currentTurn == PlayerTurn.first) player1Score++; else player2Score++; }
                    if (topBoxAwarded)
                    { if (currentTurn == PlayerTurn.first) player1Score++; else player2Score++; }

                    completedBoxWithPath = bottomBoxAwarded;
                    if (!completedBoxWithPath) completedBoxWithPath = topBoxAwarded;
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

                    bool rightBoxAwarded = rightBox.checkForCompletedWithLastPath(newPath);
                    bool leftBoxAwarded = leftBox.checkForCompletedWithLastPath(newPath);

                    if (rightBoxAwarded)
                    { if (currentTurn == PlayerTurn.first) player1Score++; else player2Score++; }
                    if (leftBoxAwarded)
                    { if (currentTurn == PlayerTurn.first) player1Score++; else player2Score++; }

                    completedBoxWithPath = rightBoxAwarded;
                    if (!completedBoxWithPath) completedBoxWithPath = leftBoxAwarded;
                }

                // Change who's turn it is.
                if (!completedBoxWithPath)
                    if (currentTurn == PlayerTurn.first) currentTurn = PlayerTurn.second;
                    else currentTurn = PlayerTurn.first;
            }

            // Clear the disabled dots.
            if (isPlayingComputer && currentTurn == PlayerTurn.second)
            {
                foreach (Dot dot in dots)
                    dot.button.Enabled = false;
                
                // Check if game over
                bool allClaimed = true;
                foreach (Box box in boxes)
                    if (!box.hasBeenClaimed)
                    {
                        allClaimed = false;
                        break;
                    }

                hasGameCompleted = allClaimed;
            }
            else
                clearDisabledDots();
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

        private void clearDisabledDots()
        {
            uint amountOfDisabledDots = 0;
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                {
                    Dot dot = dots[row, column];
                    if (!isDotAtMaxPaths(dot))
                        dot.button.Enabled = true;
                    else
                    {
                        dot.button.Enabled = false;
                        amountOfDisabledDots++;
                    }
                }

            if (amountOfDisabledDots == width * height)
                hasGameCompleted = true;
        }

        private bool doesPathExistBetweenDot(Dot dot1, Dot dot2)
        {
            foreach (Path path in paths)
                if ((path.firstDot == dot1 && path.secondDot == dot2) ||
                    ((path.firstDot == dot2 && path.secondDot == dot1)))
                    return true;

            return false;
        }

        private bool isDotAtMaxPaths(Dot dot)
        {
            uint maximumAboutOfPathsForDot = 4;
            uint currentAmountOfPaths = 0;

            if ((dot.row == 0 && dot.column == 0) || (dot.row == height - 1 && dot.column == width - 1) ||
                (dot.row == height - 1 && dot.column == 0) || (dot.row == 0 && dot.column == width - 1)) // Corners?
                maximumAboutOfPathsForDot = 2;
            else if (dot.row == 0 || dot.row == height - 1 || dot.column == 0 || dot.column == width - 1) // Edges?
                maximumAboutOfPathsForDot = 3;

            foreach (Path path in paths)
                if (path.firstDot == dot || path.secondDot == dot)
                    currentAmountOfPaths++;

            if (currentAmountOfPaths >= maximumAboutOfPathsForDot)
                return true;

            return false;
        }

    }

}
