using System;
using System.Collections.Generic;
using System.Text;

namespace MorpionServer
{
    public enum State { empty = 0, circle = 1, cross = -1 }
    public struct Coord
    {
        int x;
        int y;
        int z;
    }
    public class Square
    {
        public State state = State.empty;

        public override string ToString()
        {
            switch (state)
            {
                case State.empty:
                    return ("| ");
                case State.circle:
                    return ("|o");
                case State.cross:
                    return ("|x");
                default:
                    return ("ERROR");
            }
        }
    }

    public class Grid
    {
        public Square[,,] grid = new Square[3, 3, 3];
        public Grid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        grid[i, j, k] = new Square();
                    }
                }
            }
        }

        public object this[int i, int j, int k]
        {
            get
            {
                return ((Square)this.grid[i, j, k]);
            }
            set
            {
                this.grid[i, j, k] = (Square)value;
            }
        }

        public override string ToString()
        {
            string representation = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        representation = representation + grid[i, j, k].ToString();
                    }
                    representation = representation + "\n";
                }
                representation = representation + "\n";
            }
            return (representation);
        }

        public string  GridToString()
        {
            throw new NotImplementedException();
        }
    }
}
