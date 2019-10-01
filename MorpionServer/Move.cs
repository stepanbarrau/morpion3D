using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorpionServer
{
    public class Move

    {
        public int x;
        public int y;
        public int z;

        public Move(int[] coord)
        {
            (this.x, this.y, this.z) = (coord[0], coord[1], coord[2]);
        }

        public Square findSquare(Grid grid)
        {
            return ((Square) grid[this.x, this.y, this.z]);
        }

        internal static Move MoveFromString(string v)
        {
            throw new NotImplementedException();
        }
    }
}
