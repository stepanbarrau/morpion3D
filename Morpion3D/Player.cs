using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Morpion3D
{
    class Player
    {
        public State color = State.cross;

        public void playMove(Move move, Game game)
        {
            Square square = move.findSquare(game);
            square.state = this.color;
            Console.WriteLine(game.grid);
        }

        public Move createMove()
        {
            Console.WriteLine("choose square");
            string[] choice = Console.ReadLine().Split(',');

            var coord = (int[])choice.Select(i => Int32.Parse(i)).ToArray();
            return (new Move(coord));
        }

        public void quit(Game game)
        {
            game.stop = true;
        }

        public override string ToString()
        {
            return color.ToString();
        }
    }

    class Move
    {
        public int x;
        public int y;
        public int z;

        public Move(int[] coord)
        {
            (this.x, this.y, this.z) = (coord[0], coord[1], coord[2]);
        }

        public Square findSquare(Game game)
        {
            return ((Square)game.grid[this.x, this.y, this.z]);
        }

        //this part is for easy serialisation
        public string moveToString()
        {
            return ($"MOVE|{x}|{y}|{z}");
        }

        public static Move StringToMove(string data)
        {
            if (data.Substring(0,5) != "MOVE")
            {
                throw (new Exception("wrong format"));
            }
            int[] coord = new int[3];
            coord = (int[])data.Substring(6, 11).Split('|').Select(n => Int32.Parse(n));

            return (new Move(coord));
        } 
    }
}
