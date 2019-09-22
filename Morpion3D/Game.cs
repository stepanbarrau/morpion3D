using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion3D
{
    class Game
    {
        public Player player1 = new Player();
        public Player player2 = new Player();
        private Queue<Player> nextPlayer = new Queue<Player>();

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
                current.play(this);
                nextPlayer.Enqueue(current);
            }
        }

    }
}
