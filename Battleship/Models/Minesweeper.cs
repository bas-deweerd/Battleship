using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship.Models
{
    class Minesweeper : Ship
    {


        public Minesweeper(int id) : base(id)
        {
            this.Length = 2;
            this.Name = "Minesweeper";
        }
        internal override ImageBrush setBackground()
        {
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(new Uri(@"../../Resources/Minesweeper.png"));
            return imgbrush;
        }

        public override string ToString()
        {
            return "Minesweeper";
        }
    }
}
