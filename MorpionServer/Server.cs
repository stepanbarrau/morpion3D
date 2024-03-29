﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MorpionServer
{
    public class Server
    {
        // Singleton pattern
        static Server instance = null;
        static IPAddress adress = IPAddress.Parse("127.0.0.1");
        TcpListener listener;
        List<TcpClient> clients;
        private bool listening;
        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Server();
                }
                return instance;
            }
        }
        private Server()
        {
        }

        
        public void startListening() {
           listener = new TcpListener(adress, 8080);
            listener.Start();

            ThreadPool.QueueUserWorkItem(this.ListenerWorker, null);

        }

        private void ListenerWorker(object state)
        {
            while (listener != null)
            {
                var client = listener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(this.HandleClientWorker, client);
            }
        }

        private void HandleClientWorker(object token)
        {
            Byte[] bytes = new Byte[1024];
            StringBuilder builder = new StringBuilder();

            using (var client = token as TcpClient)
            using (var stream = client.GetStream())
            {
                int length;

                while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    builder.Append(Encoding.ASCII.GetString(bytes, 0, length));
                }

                var msg = builder.ToString();
                //do something with complete message
            }
        }

        public void stopListening() {
            if(listener != null)
            {
                listener.Stop();
                listener = null;
                
            }
        }

        public void onMoveReceived() { }

        // Send game state and ask for move
        public void askMove() { }

        public void broadcastGameState()
        {

        }


        public void runGame() { }

        public void startGame() { }
    }
}
