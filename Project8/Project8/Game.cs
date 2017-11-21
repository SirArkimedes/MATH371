using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project8
{
    class Dot
    {
        public RadioButton button { get; private set; }

        public Dot(RadioButton button)
        {
            this.button = button;
        }
    }

    class Path
    {
        
    }

    class Box
    {

    }

    // Class that manages the Game's state.
    class Game
    {
        private enum ClickState
        {
            none,
            inProgress
        };

        public Dot[,] dots;

        private uint width = 0;
        private uint height = 0;

        private ClickState currentClickState = ClickState.none;
        private Dot currentClickedDot;

        public Game(uint width, uint height)
        {
            dots = new Dot[width, height];

            this.width = width;
            this.height = height;
        }

        /***********************/
        /* Event Handlers      */
        /***********************/

        public void handleClick(RadioButton button)
        {
            Dot senderDot = null;
            foreach (Dot dot in dots)
                if (dot.button == button)
                {
                    senderDot = dot;
                    break;
                }

            if (senderDot != null) // Just making sure we found the Dot.
                if (currentClickState == ClickState.none) // Button gets selected before the click handler gets called.
                    handleFirstClick(senderDot);
                else
                    handleSecondClick(senderDot);

        }

        /***********************/
        /* Helpers             */
        /***********************/

        private void handleFirstClick(Dot senderDot)
        {
            currentClickState = ClickState.inProgress;
            currentClickedDot = senderDot;

            Tuple<int, int> coordinatesOfSender = dots.coordinatesOf(senderDot);
            int indexColumn = coordinatesOfSender.Item2;
            int indexRow = coordinatesOfSender.Item1;

            List<Dot> unselectedDots = new List<Dot>();
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

            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    dots[row, column].button.Enabled = true;
        }
    }
}
