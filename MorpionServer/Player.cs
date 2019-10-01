using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MorpionServer
{
    interface Player
    {
        /// <summary>
        /// Method to ask the User for a Move
        /// </summary>
        /// <returns>Move</returns>
        string AskMove();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void SendCurrentState(GameState state);
    }

    public class TcpPlayer : Player
    {
        TcpClient client;

        public TcpPlayer(TcpClient client)
        {
            this.client = client;
        }

        public string AskMove()
        {
            throw new NotImplementedException();
        }

        public void SendCurrentState(GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
