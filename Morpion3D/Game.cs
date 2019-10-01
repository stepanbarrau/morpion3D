using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion3D
{
    class Game
    {
        public Rules rules = new Rules();
        public Player player1 = new Player();
        public Player player2 = new Player();
        public Queue<Player> nextPlayer = new Queue<Player>();

        public Grid grid = new Grid();
        public bool stop = false;
        
        public Game()
        {
            player1.color = State.circle;
            player2.color = State.cross;
        }

        public void start()
        {
            nextPlayer.Enqueue(player1);
            nextPlayer.Enqueue(player2);
            while (!stop)
            {
                Player current = nextPlayer.Dequeue();
                bool hasMadeValidMove = false;
                Move move;
                do
                {
                    move = current.createMove();
                    hasMadeValidMove = rules.isValidMove(move, current, this);
                    Console.WriteLine(hasMadeValidMove ? "good move" : "move invalid");
                } while (!hasMadeValidMove);

                current.playMove(move, this);
                if(rules.winCheck(move, current, this))
                {
                    Console.WriteLine($"{current} has won!");
                    stop = true;
                }
                
                nextPlayer.Enqueue(current);
            }
            Console.ReadKey();
        }

    }
}
