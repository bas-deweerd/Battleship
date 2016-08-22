using System;
using Client.Views;

namespace Client.Models
{
    public class BotRandom : Player
    {
        public BattleGrid OpponentSea;

        public void PlaceAllShips(BattleGrid grid)
        {
            Random random = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                while (!this.Ships[i].Placed)
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
                    grid.NextToBePlacedShip = Ships[i];
                    grid.Click(row, column);
                }
            }
        }

        public void Fire()
        {
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

        public override void Notify()
        {
            Fire();
        }
    }
}
