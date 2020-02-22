using MontyHallParadox.Players;
using System;

namespace MontyHallParadox
{
    class Program
    {
        private const int _attemptsCount = 1_000_000;

        static void Main(string[] args)
        {
            int totalStickyWin = 0;
            int totalSwitchWin = 0;

            for(int attempt = 0; attempt < _attemptsCount; attempt++)
            {
                var stickyPlayResult = PlayGame(new StickPlayer());
                if (stickyPlayResult == Result.Win)
                    totalStickyWin++;

                var switchPlayResult = PlayGame(new SwitchPlayer());
                if (switchPlayResult == Result.Win)
                    totalSwitchWin++;
            }

            Console.WriteLine($"Sticky success rate = {100 * totalStickyWin / _attemptsCount}%");
            Console.WriteLine($"Switch success rate = {100 * totalSwitchWin/ _attemptsCount}%");
        }

        private static Result PlayGame(PlayerBase player)
        {
            var game = new Game();
            player.Play(game);
            return game.FinishGame();
        }
    }
}
