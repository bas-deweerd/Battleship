using System.Linq;

namespace Client.Models
{
    public class Player
    {
        public Ship[] Ships = new Ship[5];
        public Turn Turn;

        public Player()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetShips();

        }

        public virtual void Notify() {

        }

        public bool AllShipsSunk()
        {
            foreach(Ship ship in Ships) {
                if (ship.Sunk== false)
                {
                    return false;
                }
            }
            return true;
        }

        private void SetShips()
        {
            Ships[0] = new Client.Models.Battleship(0);
            Ships[1] = new Cruiser(1);
            Ships[2] = new Frigato(2);
            Ships[3] = new Frigato(3);
            Ships[4] = new Minesweeper(4);
        }

        public bool AllShipsPlaced()
        {
            return Ships.All(ship => ship.Placed != false);
        }


        public Ship GetShip(string ship)
        {
            switch (ship)
            {
                case "Minesweeper":
                    return Ships[4];
                case "Frigato":
                    return Ships[3].Placed == false ? Ships[3] : Ships[2];
                case "Cruiser":
                    return Ships[1];
                case "Battleship":
                    return Ships[0];
                default:
                    return null;
            }
        }
    }
}
