using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Battleship.Models
{
    class PoorManShip:Ship
    {
        public PoorManShip(int id) : base(id)
        {
            this.Length = 1;
            this.Name = "PoorManShip";
        }

        internal override ImageBrush setBackground()
        {
            throw new NotImplementedException();
        }
    }
}
