using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Views;

namespace Battleship.Models
{
    public class Player
    {
        public Ship[] ships = new Ship[5];
        public Turn turn;

        public Player()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetShips();

        }

        public virtual void notify() {

        }

        public bool allShipsSunk()
        {
            foreach(Ship ship in ships) {
                if (ship.Sunk== false)
                {
                    return false;
                }
            }
            return true;
        }

        private void SetShips()
        {
            ships[0] = new Battleship(0);
            ships[1] = new Cruiser(1);
            ships[2] = new Frigato(2);
            ships[3] = new Frigato(3);
            ships[4] = new Minesweeper(4);
        }

        public bool AllShipsPlaced() {

            foreach (Ship ship in ships) {
                if (ship.Placed == false)
                {
                    return false;
                }
            }
            return true;
        }



        public Ship getShip(string ship)
        {
            switch (ship)
            {
                case "Minesweeper":
                    return ships[4];
                case "Frigato":
                    if (ships[3].Placed == false)
                    {
                        return ships[3];
                    }
                    else
                    {
                        return ships[2];
                    }
 

                case "Cruiser":

                        return ships[1];


                case "Battleship":

                        return ships[0];

            }
            return null;
        }
    }
}
