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

            this.Icon = new BitmapImage();
            this.Icon.BeginInit();

            this.Icon.StreamSource = Assembly.GetExecutingAssembly()
                                   .GetManifestResourceStream(filename); 

            this.Icon.EndInit();
        }

        public Fighter(Colors color, GameBoard board, int x, int y) : this(color, board)
        {
            this.Move(x, y);
        }

        public override bool Canmove(int x, int y)
        {
           
            return true;
        }
        public System.IO.Stream StreamSource { get; set; }
    }
}
