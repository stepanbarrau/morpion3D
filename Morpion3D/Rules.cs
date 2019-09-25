using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion3D
{
    class Rules
    {
        public bool isValidMove(Move move, Player player, Game game)
        {
            if (move.findSquare(game).state == State.empty){
                return (true);
            }
            return (false);
        }
        public bool winCheck(Move move, Player player, Game game)
        {
            State color = player.color;



            var range = Enumerable.Range(0,3);
            var directions_ = from x in range from y in range from z in range select new { x, y, z };
            var directions = directions_.Select((i) => new {x = i.x - 1, y = i.y-1, z = i.z-1 });

            //Console.WriteLine(directions.Count());
            

            foreach(var direction in directions)
            {
                //Console.WriteLine("{0} {1} {2}", direction.x, direction.y, direction.z);
                
                if((direction.x, direction.y, direction.z) != (0, 0, 0))
                {
                    var position = new { x = move.x, y = move.y, z = move.z };
                    int consecutives = 0;
                    
                    try
                    {
                        Square next = (Square)game.grid[position.x + direction.x, position.y + direction.y, position.z + direction.z];
                        while (next.state == color) 
                        {
                            position = new { x = position.x + direction.x, y = position.y + direction.y, z =  position.z + direction.z };
                            consecutives++;

                            next = (Square)game.grid[position.x + direction.x, position.y + direction.y, position.z + direction.z];


                        } 
                    }
                    catch { };
                    position = new { x = move.x, y = move.y, z = move.z };
                    try
                    {
                        Square next = (Square)game.grid[position.x - direction.x, position.y - direction.y, position.z - direction.z];
                        while (next.state == color)
                        {
                            position = new { x = position.x - direction.x, y = position.y - direction.y, z = position.z - direction.z };
                            consecutives++;
                            next = (Square)game.grid[position.x - direction.x, position.y - direction.y, position.z - direction.z];
                            


                        } 
                    }
                    catch { };
 
                    // Console.WriteLine($"consecutives : {consecutives}");
                    if (consecutives >= 2)
                    {
                        return (true);
                    }
                   
                }
                
            }
            return (false);

            
        }
    }
}
