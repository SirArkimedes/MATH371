using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFinal
{
    public enum Difficulty { easy, medium, insane }

    class GameBot
    {
        private Game game;

        private Path insaneBestPath;

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
            insaneBestPath = null;

            game.isGameSimulation = true;

            alphaBeta(uint.MinValue, uint.MaxValue, 1);

            game.isGameSimulation = false;
            game.currentTurn = Game.PlayerTurn.second;

            if (insaneBestPath == null)
                return getMediumPlay();

            return insaneBestPath;
        }

        private uint alphaBeta(uint alpha, uint beta, uint depth)
        {
            List<Path> notPlayedPaths = game.paths.Where(ePath => ePath.playerWhoPlayedPath == Game.PlayerTurn.none).ToList();
            if (notPlayedPaths.Count > 13)
            {
                insaneBestPath = getMediumPlay();
                return 0;
            }

            if (notPlayedPaths.Count == 1)
            {
                if (depth == 1)
                    insaneBestPath = notPlayedPaths[0];
                
                uint firstPlayerScoreSave = game.player1Score;
                uint secondPlayerScoreSave = game.player2Score;

                game.handleClick(notPlayedPaths[0].secondDot.button);
                game.handleClick(notPlayedPaths[0].firstDot.button);

                uint score = game.player2Score;
                notPlayedPaths[0].setWhoPlayedPath(Game.PlayerTurn.none);
                game.setScores(firstPlayerScoreSave, secondPlayerScoreSave);

                return score;
            }

            if (game.currentTurn == Game.PlayerTurn.second)
            {
                uint value = uint.MinValue;
                
                foreach (Path ePath in notPlayedPaths)
                {
                    game.currentTurn = Game.PlayerTurn.second;
                    uint firstPlayerScoreSave = game.player1Score;
                    uint secondPlayerScoreSave = game.player2Score;

                    game.handleClick(ePath.secondDot.button);
                    game.handleClick(ePath.firstDot.button);

                    uint newTest = alphaBeta(alpha, beta, depth + 1);
                    if (newTest > value)
                    {
                        if (depth == 1)
                            insaneBestPath = ePath;
                        value = newTest;
                    }
                    alpha = Math.Max(alpha, value);

                    ePath.setWhoPlayedPath(Game.PlayerTurn.none);
                    game.setScores(firstPlayerScoreSave, secondPlayerScoreSave);

                    if (beta <= alpha)
                        break;
                }

                return value;
            }
            else
            {
                uint value = uint.MaxValue;
                
                foreach (Path ePath in notPlayedPaths)
                {
                    game.currentTurn = Game.PlayerTurn.first;
                    uint firstPlayerScoreSave = game.player1Score;
                    uint secondPlayerScoreSave = game.player2Score;

                    game.handleClick(ePath.secondDot.button);
                    game.handleClick(ePath.firstDot.button);

                    uint newTest = alphaBeta(alpha, beta, depth + 1);
                    if (newTest < value)
                    {
                        if (depth == 1)
                            insaneBestPath = ePath;
                        value = newTest;
                    }
                    beta = Math.Min(beta, value);

                    ePath.setWhoPlayedPath(Game.PlayerTurn.none);
                    game.setScores(firstPlayerScoreSave, secondPlayerScoreSave);

                    if (beta <= alpha)
                        break;
                }

                return value;
            }

        }
    }
}
