using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Turn
    {
        private int activeplayer=0;
        private Player[] players = new Player[2];
        public GameModel model;
 


        public Turn(Player one, Player two) {
            players[0] = one;
            players[1] = two;
        }



        public void SwitchTurn()
        {
            activeplayer = (activeplayer + 1) % 2;
            players[activeplayer].notify();
            if (players[0].allShipsSunk() || players[1].allShipsSunk())
            {
                model.NextPhase();
            }
        }

        public Player getActivePlayer()
        {
            return players[activeplayer];
        }

    }
}
