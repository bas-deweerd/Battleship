using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    class SinglePlayerGame
    {
        private Player one, two;
        private Turn turn;

        public SinglePlayerGame(Player one) {
            this.one = one;
            this.two = new SimpleBot();
            this.turn = new Turn(one, two);
        }

    }
}
