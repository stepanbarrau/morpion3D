using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MorpionServer
{
    public class Game
    {
        private Player pl1;
        private Player pl2;
        private Grid grid;
        private GameState state;

        public Game(Player pl1, player pl2)
        {
            this.pl1 = pl1;
            this.pl2 = pl2;
        }

        /// <summary>
        /// initialise the game state
        /// </summary>
        private void Initialize()
        {
            this.state = new GameState();
        }

        /// <summary>
        /// Send the game state to all players
        /// </summary>
        private void broadcastState()
        {
            pl1.SendCurrentState(state);
            pl1.SendCurrentState(state);
        }
    }
}
