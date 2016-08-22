using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Battleship.Models
{
    /// <summary>
    /// Model of a ship. Ships may vary in length.
    /// </summary>
    public abstract class Ship
    {
        List<Position> positions = new List<Position>();
        public string Name { get; set; }
        private int id;
        public int ID { get { return id; } set { this.id = value; } }
        private Boolean active = true;
        public Boolean Active { get { return active; } set { this.active = value; } }
        private int length;
        public int Length { get { return length; } set { length = value; } }
        private bool sunk = false;
        public bool Sunk { get { return sunk; } set { this.sunk = value; } }
        private Brush Image
        {
            get
            { return setBackground(); }
        }

        private bool placed = false;
        public bool Placed { get { return placed; } set { placed = true; } }

        public Ship(int id) {
            this.ID = id;
        }

        internal abstract ImageBrush setBackground();

        internal void addPosition(Position position)
        {
            positions.Add(position);
        }

        internal void hit()
        {
            length--;
            if (length == 0)
            {
                sunk = true;
                positions.ForEach(delegate(Position tosink)
                {
                    tosink.CurrentState = State.Sunk;
                });
            }
        }
    }
}
