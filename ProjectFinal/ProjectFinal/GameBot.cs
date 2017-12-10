using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFinal
{
    public enum Difficulty { easy, medium, insane }

    class GameBot
    {
        private Game game;

        public Path determineMove(Game game, Difficulty difficulty)
        {
            this.game = game;

            if (difficulty == Difficulty.easy)
                return getEasyPlay();
            else if (difficulty == Difficulty.medium)
                return getMediumPlay();
            else
                return getInsanePlay();
        }

        /***********************/
        /* Easy                */
        /***********************/

        private Path getEasyPlay()
        {
            List<Path> notPlayedPaths = game.paths.Where(ePath => ePath.playerWhoPlayedPath == Game.PlayerTurn.none).ToList();

            Random random = new Random();
            int playPathIndex = random.Next(0, notPlayedPaths.Count);

            return notPlayedPaths[playPathIndex];
        }

        /***********************/
        /* Medium              */
        /***********************/

        private Path getMediumPlay()
        {
            List<Path> notPlayedPaths = game.paths.Where(ePath => ePath.playerWhoPlayedPath == Game.PlayerTurn.none).ToList();

            Random random = new Random();
            int numberOfBoxesWithTwoSides = -1;
            bool shouldFindNewPlay = true;

            Path play = null;

            while (shouldFindNewPlay && notPlayedPaths.Count > 0)
            {
                int playIndex = random.Next(0, notPlayedPaths.Count);
                play = notPlayedPaths[playIndex];

                numberOfBoxesWithTwoSides = 0;

                bool shouldPlayCurrentBox = true;
                foreach (Box box in game.boxes)
                {
                    List<Path> pathsToCheck = new List<Path>();
                    pathsToCheck.Add(box.top);
                    pathsToCheck.Add(box.bottom);
                    pathsToCheck.Add(box.left);
                    pathsToCheck.Add(box.right);

                    bool isPlayBox = false;
                    // Does this box contain the path that was chosen?
                    if (box.top == play) isPlayBox = true;
                    else if (box.bottom == play) isPlayBox = true;
                    else if (box.left == play) isPlayBox = true;
                    else if (box.right == play) isPlayBox = true;
                    
                    int boxesPlayedPaths = 0;
                    foreach (Path path in pathsToCheck)
                        if (path.playerWhoPlayedPath != Game.PlayerTurn.none)
                            boxesPlayedPaths++;

                    if (boxesPlayedPaths >= 2)
                    {
                        numberOfBoxesWithTwoSides++;
                        if (isPlayBox)
                            shouldPlayCurrentBox = false;
                    }
                }

                if (shouldPlayCurrentBox)
                    shouldFindNewPlay = false;

                if (shouldFindNewPlay)
                    notPlayedPaths.RemoveAt(playIndex);
            }

            if (notPlayedPaths.Count == 0)
                return getEasyPlay();

            return play;
        }

        /***********************/
        /* Insane              */
        /***********************/

        private Path getInsanePlay()
        {
            List<Path> notPlayedPaths = game.paths.Where(ePath => ePath.playerWhoPlayedPath == Game.PlayerTurn.none).ToList();

            Random random = new Random();
            int playPathIndex = random.Next(0, notPlayedPaths.Count);

            return notPlayedPaths[playPathIndex];
        }
    }
}
