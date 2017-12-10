using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFinal
{
    public enum Difficulty { easy, medium, insane }

    class GameBot
    {
        private Game game;

        public Path determineMoveFromGame(Game game, Difficulty difficulty)
        {
            this.game = game;

            List<Path> notPlayedPaths = game.paths.Where(ePath => ePath.playerWhoPlayedPath == Game.PlayerTurn.none).ToList();

            Random random = new Random();
            int playPathIndex = random.Next(0, notPlayedPaths.Count);

            return notPlayedPaths[playPathIndex];
        }
    }
}
