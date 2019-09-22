using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Morpion3D
{
    class Player
    {
        public State color = State.cross;
        public void play(Game game)
        {
            Console.WriteLine("choose square");
            string[] choice = Console.ReadLine().Split(',');

            var coord = (int[])choice.Select(i => Int32.Parse(i)).ToArray() ;
            Square square = (Square)game.grid[coord[0],coord[1],coord[2]];

            square.state = this.color;
            Console.WriteLine(game.grid);
        }

        public void quit(Game game)
        {
            game.stop = true;
        }
    }
}
