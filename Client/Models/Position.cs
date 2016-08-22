using System.Windows.Controls;
using System.Windows.Media;

namespace Client.Models
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
        private readonly int _row, _column;
        private State _currentstate;
        public State CurrentStateMyProperty { get { return _currentstate; } set { } }
        private Ship _ship;
        
        public Ship OwnedShip { get { return _ship; } set { this._ship = value; _ship.AddPosition(this); } }
        /// <summary>
        /// Sets or gets the current state. Automatically changes background color.
        /// </summary>
        public State CurrentState
        {
            get
            {
                return _currentstate;
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
                if (value == State.OccupiedHidden)
                {
                    this.Background = Brushes.Blue;
                }
                this._currentstate = value;
            }
        }

        public Position(int row, int column) {
            this._row = row;
            this._column = column;
            this.Background = Brushes.Blue;
            this._currentstate = State.Sea;
        }

        public int GetRow()
        {
            return _row;
        }

        public int GetColumn()
        {
            return _column;
        }

        internal void Hit()
        {
            if (_ship != null)
            {
                CurrentState = State.Hit;
                _ship.Hit();
            }
            else
            {
                CurrentState = State.Miss;
            }
        }
    }
}
