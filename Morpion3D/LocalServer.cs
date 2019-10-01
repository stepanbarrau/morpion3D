//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Morpion3D
//{
//    class LocalServer
//    {
//        Game game = new Game();
//        public void start()
//        {
//            bool stop = false;
//            while (!stop)
//            {
//                client.receiveMessage()
//                Player current = game.nextPlayer.Dequeue();
//                bool hasMadeValidMove = false;
//                Move move;
//                do
//                {
//                    move = current.createMove();
//                    hasMadeValidMove = rules.isValidMove(move, current, this);
//                    Console.WriteLine(hasMadeValidMove ? "good move" : "move invalid");
//                } while (!hasMadeValidMove);

//                current.playMove(move, this);
//                if (rules.winCheck(move, current, this))
//                {
//                    Console.WriteLine($"{current} has won!");
//                    stop = true;
//                }

//                nextPlayer.Enqueue(current);
//            }
//            Console.ReadKey();
//        }

//    }

//    class LocalClient
//    {
//        public byte[] 
//    }
         
//}
