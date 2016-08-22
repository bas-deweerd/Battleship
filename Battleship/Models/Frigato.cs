using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship.Models
{
    class Frigato : Ship
    {
        public Frigato(int id) : base(id)
        {
            this.Length = 3;
            this.Name = "Frigato";
        }

        internal override ImageBrush setBackground()
        {
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(new Uri(@"../../Resources/frigato.png"));
            return imgbrush;
        }

        public override string ToString()
        {
            return "Frigato";
        }
    }
}
