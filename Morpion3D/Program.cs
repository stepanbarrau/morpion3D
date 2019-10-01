using System;

namespace Morpion3D
{
    class Program
    {
        static void Main(string[] args)
        {

            //Game game = new Game();
            //Console.WriteLine(game.grid);

            //game.start();
            Grid grid = new Grid();
            Console.WriteLine(Grid.stringToGrid(grid.gridToString()));
        }
    }
}
