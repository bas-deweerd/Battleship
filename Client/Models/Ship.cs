using System;
using System.Collections.Generic;

namespace Client.Models
{
    /// <summary>
    /// Model of a ship. Ships may vary in length.
    /// </summary>
    public abstract class Ship
    {
        List<Position> positions = new List<Position>();
        private int id;
        public int ID { get { return id; } set { this.id = value; } }
        private Boolean _active = true;
        public Boolean Active { get { return _active; } set { this._active = value; } }
        private int _length;
        public int Length { get { return _length; } set { _length = value; } }
        private bool _sunk = false;
        public bool Sunk { get { return _sunk; } set { this._sunk = value; } }

        private bool _placed = false;
        public bool Placed { get { return _placed; } set { _placed = true; } }

        public Ship(int id) {
            this.ID = id;
        }

        internal void AddPosition(Position position)
        {
            positions.Add(position);
        }

        internal void Hit()
        {
            _length--;
            if (_length == 0)
            {
                _sunk = true;
                positions.ForEach(delegate(Position tosink)
                {
                    tosink.CurrentState = State.Sunk;
                });
            }
        }
    }
}
