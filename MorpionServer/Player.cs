using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;


namespace MorpionServer
{
    public interface Player
    {
        /// <summary>
        /// Method to ask the User for a Move
        /// </summary>
        /// <returns>Move</returns>
        Move AskMove();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void SendCurrentState(Grid grid);
    }

    public class TcpPlayer : Player
    {
        readonly TcpClient client;
        private readonly NetworkStream stream;

        public TcpPlayer(TcpClient client)
        {
            this.client = client;
            this.stream = client.GetStream();
        }

        public Move AskMove()
        {
            var msg = Encoding.UTF8.GetBytes("Play");
            stream.Write(msg, 0, msg.Length);
            while (client.Connected)
            {
                var answer = new byte[1024];
                stream.Read(answer, 0, answer.Length);
                try
                {
                    var move = Move.MoveFromString(Encoding.UTF8.GetString(answer));
                    return move;
                } catch { }
            }
            return null;

            
        }

        public void SendCurrentState(Grid grid)
        {
            var msg = Encoding.UTF8.GetBytes(grid.GridToString());

        }
    }
}
