using System;

namespace Morpion3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine(game.grid);

            game.start();
        }
    }
}
