using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship.Models
{
    class Battleship : Ship
    {



        public Battleship(int id) : base(id) {
            Length = 5;
            this.Name = "Battleship";
        }

        internal override ImageBrush setBackground()
        {
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(new Uri(@"../../Resources/battleship.png"));
            return imgbrush;
        }

        public override string ToString() {
            return "Battleship";
        }
    }
}
