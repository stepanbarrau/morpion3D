using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;


namespace MorpionServer
{
    public class Game
    {
        private  Player pl1 { get; set; }
        private  Player pl2 { get; set; }
        private Grid grid;

        public Game(Player play1, Player play2)
        {
            this.pl1 = play1;
            this.pl2 = play2;
        }

        /// <summary>
        /// initialise the game state
        /// </summary>
        private void Initialize()
        {
            this.grid = new Grid();
        }

        /// <summary>
        /// Send the game state to all players
        /// </summary>
        private void broadcastState()
        {
            pl1.SendCurrentState(grid);
            pl1.SendCurrentState(grid);
        }
    }
}
