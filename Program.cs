using System;

namespace Quoridor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Game game = new Game();

            game.Run();
        }
    }
}
