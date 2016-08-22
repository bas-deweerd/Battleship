using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Views;

namespace Battleship.Models
{
    public class BotRandom : Player
    {
        public BattleGrid OpponentSea;
        

        public void PlaceAllShips(BattleGrid grid)
        {
            Random random = new Random();
            

            for (int i = 0; i < 5; i++)
            {
                while (this.ships[i].Placed == false)
                {
                    int row = random.Next(0, 10);
                    int column = random.Next(0, 10);
                    int orientation = random.Next(0, 2);
                    if (orientation == 0)
                    {
                        grid.PlacingShipsOrientation = Orientation.Horizontal;
                    }
                    else
                    {
                        grid.PlacingShipsOrientation = Orientation.Vertical;
                    }
                    grid.NextToBePlacedShip = ships[i];
                    grid.Click(row, column);
                }
            }
        }

        public sealed override void notify()
        {
            Fire(); 
        }

        public void Fire()
        {
            Console.WriteLine("Fired.");
            Random random = new Random();
            Boolean fired = false;
            while (fired == false)
            {
                int row = random.Next(0, 10);
                int column = random.Next(0, 10);
                Position pos = OpponentSea.Grid.GetPosition(row, column);
                if (pos.CurrentState == State.Sea || pos.CurrentState == State.Occupied)
                {
                    OpponentSea.Click(row, column);
                    fired = true;
                }
            }
        }
    }
}
