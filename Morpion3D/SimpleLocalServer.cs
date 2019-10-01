using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion3D
{
    //class LocalServer
    //{
    //    Game game = new Game();
    //    public void start()
    //    {
    //        bool stop = false;
    //        while (!stop)
    //        {
    //            client.receiveMessage()
    //            Player current = game.nextPlayer.Dequeue();
    //            bool hasMadeValidMove = false;
    //            Move move;
    //            do
    //            {
    //                move = current.createMove();
    //                hasMadeValidMove = rules.isValidMove(move, current, this);
    //                Console.WriteLine(hasMadeValidMove ? "good move" : "move invalid");
    //            } while (!hasMadeValidMove);

    //            current.playMove(move, this);
    //            if (rules.winCheck(move, current, this))
    //            {
    //                Console.WriteLine($"{current} has won!");
    //                stop = true;
    //            }

    //            nextPlayer.Enqueue(current);
    //        }
    //        Console.ReadKey();
    //    }

    //}

    class LocalClient
    {
        public byte[] outboundMessage;

        public void playMove()
        {
            // demande à l'utilisateur un move en ligne de commande et le transforme en message standard
            Console.WriteLine("please choose a square");
            int x = -1;
            int y = -1;
            int z = -1;
            int[] coord = { x, y, z };

            //checking that the user gave correct input
            try
            {
                string[] choice = Console.ReadLine().Split(',');

                coord = (int[])choice.Select(i => Int32.Parse(i)).ToArray();

                //we check that all coordinates are between 0 and 2
                foreach (int i in coord) {
                    if (i < 0 || i > 2)
                    {
                        throw (new Exception("coordinated not in range"));
                    }
                }
            }
            catch(Exception e) {
                //if we can't parse the message into coordinates, then we try asking again
                Console.WriteLine(e);
                Console.WriteLine("please use correct syntax : x,y,z and give coordinates between 0 and 2");
                
                this.playMove();
            }

            Console.WriteLine($"playing move {x},{y},{z}");
            Move move = new Move(coord);
            outboundMessage = Encoding.UTF8.GetBytes(move.ToString());
        }

        public void displayGridState(byte[] message)
        {
            // the message must be 
            string[] data = Encoding.UTF8.GetString(message).Split(',');
            Grid grid = new Grid();
            int currentIndex = 0;
            for(int i = 0; i<3; i++)
            {
                for (int j = 0; i < 3; i++)
                {
                    for (int k = 0; i < 3; i++)
                    {
                        switch (data[currentIndex])
                        {
                            case " ":
                            {
                                //grid[i,j,k] = 
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }
                        currentIndex++;
                    }
                }
            }
            Console.WriteLine(grid);
        }


    }

}
