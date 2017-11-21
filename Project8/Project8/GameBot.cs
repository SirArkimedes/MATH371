using System;

namespace Project8
{
    class GameBot
    {
        private enum Direction { left, right, up, down }

        private Game game;

        public int[] determineMoveFromGame(Game game)
        {
            this.game = game;

            int[] play = generateRandomPath();
            while (doesPathExist(play))
                play = generateRandomPath();

            return play;
        }

        private int[] generateRandomPath()
        {
            // Random.Next is exclusive upper bound...
            Random random = new Random();
            int firstChoiceRow = random.Next(0, game.height);
            int firstChoiceColumn = random.Next(0, game.width);

            Direction direction = (Direction) random.Next(0, 4);

            while(!canGoInDirection(direction, firstChoiceRow, firstChoiceColumn))
                direction = (Direction)random.Next(0, 4);

            int secondChoiceRow = 0;
            int secondChoiceColumn = 0;

            switch (direction)
            {
                case Direction.left:
                    secondChoiceRow = firstChoiceRow;
                    secondChoiceColumn = firstChoiceColumn - 1;
                    break;
                case Direction.right:
                    secondChoiceRow = firstChoiceRow;
                    secondChoiceColumn = firstChoiceColumn + 1;
                    break;
                case Direction.up:
                    secondChoiceRow = firstChoiceRow - 1;
                    secondChoiceColumn = firstChoiceColumn;
                    break;
                case Direction.down:
                    secondChoiceRow = firstChoiceRow + 1;
                    secondChoiceColumn = firstChoiceColumn;
                    break;
            }

            return new int[] { firstChoiceRow, firstChoiceColumn, secondChoiceRow, secondChoiceColumn };
        }

        private bool canGoInDirection(Direction direction, int row, int column)
        {
            if (row == 0 && direction == Direction.up)
                return false;
            else if (row == game.height - 1 && (direction == Direction.down))
                return false;
            else if (column == 0 && direction == Direction.left)
                return false;
            else if (column == game.width - 1 && direction == Direction.right)
                return false;

            return true;
        }

        private bool doesPathExist(int[] play)
        {
            foreach (Path path in game.paths)
            {
                // Check to see if this path already exists, if so, generate a new one.
                if ((path.firstDot.row == play[0] &&
                    path.firstDot.column == play[1] &&
                    path.secondDot.row == play[2] &&
                    path.secondDot.column == play[3]) ||
                    (path.firstDot.row == play[2] &&
                    path.firstDot.column == play[3] &&
                    path.secondDot.row == play[0] &&
                    path.secondDot.column == play[1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
