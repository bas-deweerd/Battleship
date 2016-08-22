using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship.Models
{
    class Cruiser : Ship
    {
        public Cruiser(int id) : base(id)
        {
            this.Length = 4;
            this.Name = "Cruiser";
        }

        internal override ImageBrush setBackground()
        {
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(new Uri(@"../../Resources/cruiser.png"));
            return imgbrush;
        }

        public override string ToString()
        {
            return "Cruiser";
        }
    }
}
