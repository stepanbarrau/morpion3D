using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;

namespace MorpionServer
{
    public class ClientHandler
    {
        static private ConcurrentQueue<TcpClient> tcpClients;
        static private TcpClient cl1;
        static private TcpClient cl2;

        static void addClientToQueue(TcpClient client)
        {
            tcpClients.Enqueue(client);

            // Try launching a game if enough players
            if (tcpClients.Count >= 2)
            {
                
                
                tcpClients.TryDequeue(out cl1);
                tcpClients.TryDequeue(out cl2);
                if (cl1 != null & cl2 != null)
                {
                    ThreadPool.QueueUserWorkItem(startGame);

                }
            }
        }
        static void startGame(object obj)
        {
            var game = new Game(cl1, cl2);
        }
    }


}
