using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Battleship.Models
{
    /// <summary>
    /// Model of the position.
    /// A position is a spot (row- and column-number) on a <see cref="BattleGridModel"/>.
    /// Every position has one of the following states:
    /// <list type="bullet">
    /// <item><description>Sea (no ship, no bomb)</description></item>
    /// <item><description>Occupied (by a ship, not yet bombed)</description></item>
    /// <item><description>Hit (position occupied by a ship, bombed)</description></item>
    /// <item><description>Miss (no ship, bombed)</description></item>
    /// </list>
    /// </summary>
    public class Position : Button
    {
        private int row,column;
        private State currentstate;
        public State CurrentStateMyProperty { get { return currentstate; } set { } }
        private Ship ship;
        
        public Ship OwnedShip { get { return ship; } set { this.ship = value; ship.addPosition(this); } }
        /// <summary>
        /// Sets or gets the current state. Automatically changes background color.
        /// </summary>
        public State CurrentState
        {
            get
            {
                return currentstate;
            }
            set
            {
                if (value == State.Occupied)
                {
                    this.Background = Brushes.SaddleBrown;
                }
                if (value == State.Hit)
                {
                    this.Background = Brushes.Crimson;
                }
                if (value == State.Miss)
                {
                    this.Background = Brushes.Aqua;
                }
                if (value == State.Sea)
                {
                    this.Background = Brushes.Blue;
                }
                if (value == State.Sunk)
                {
                    this.Background = Brushes.Red;
                }

                this.currentstate = value;
            }
        }

        public Position(int row, int column) {
            this.row = row;
            this.column = column;
            this.Background = Brushes.Blue;
            this.currentstate = State.Sea;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return column;
        }

        internal void Hit()
        {
            if (ship != null)
            {
                CurrentState = State.Hit;
                ship.hit();
            }
            else
            {
                CurrentState = State.Miss;
            }

        }


        //ImageBrush imgbrush = new ImageBrush();
        //imgbrush.ImageSource = new BitmapImage(new Uri(@"../../../Resources/blue.png"));


    }
}
