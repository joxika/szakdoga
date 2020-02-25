using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Szakdoga
{
    class Fighter : Unit
    {
        public Fighter(Colors color, GameBoard board)
        {
            this.Color = color;
            this.Board = board;

            var filename = String.Format("Szakdoga.{0}.Fighter.png", color == Colors.Black ? "Black" : "White");

            this.Image = new BitmapImage();
            this.Image.BeginInit();
            this.Image.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);
            this.Image.EndInit();
        }

        public Fighter(Colors szin, GameBoard board, int x, int y) : this(szin, board)
        {

            this.Lepes(x, y);
        }

        public override bool Lephet(int x, int y)
        {

            if (PositionX == 0)
                return true;

            var celPanel = GetPanel(x, y);
            if (celPanel.Children.Count != 0)
                return false;

            if (Math.Abs(x - PositionX) == 1 && Math.Abs(y - PositionY) == 1)
                return true;
            if (Math.Abs(x - PositionX) == 0 && Math.Abs(y - PositionY) == 1)
                return true;
            if (Math.Abs(x - PositionX) == 1 && Math.Abs(y - PositionY) == 0)
                return true;
            if (Math.Abs(x - PositionX) == 0 && Math.Abs(y - PositionY) == 0)
                return true;
           

            return false;
        }
    }
}
