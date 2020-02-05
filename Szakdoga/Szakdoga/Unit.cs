using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Szakdoga
{
    public abstract class Unit
    {
        public enum Colors { Black, White };

        public Colors Color { get; protected set; }
        protected int PositionX { get; set; }
        protected int PositionY { get; set; }
        public BitmapImage Icon { get; protected set; }
        public GameBoard Board { get; protected set; }

        public abstract bool Canmove(int x, int y);

        public void Move(int x, int y)
        {
            if (Canmove(x, y))
            {
                if (this.PositionX != 0)
                {
                    int indexRegi = (8 - this.PositionY) * 9 + (this.PositionX);
                    ((StackPanel)this.Board.Children[indexRegi]).Children.Clear();
                }

                int index = (8 - y) * 9 + (x);
                var panel = (StackPanel)this.Board.Children[index];
                panel.Children.Clear();

                var img = new Image()
                {
                    Source = this.Icon
                };
                img.MouseDown += Img_MouseDown;
                panel.Children.Add(img);

                this.PositionX = x;
                this.PositionY = y;
            }
            else
            {
                throw new Exception("not allowed move");
            }
        }

        private void Img_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Board.ReColor();
            var panel = GetPanel(PositionX, PositionY);
            panel.Background = Brushes.Yellow;
        }

        protected StackPanel GetPanel(int x, int y)
        {
            int index = (8 - y) * 9 + (x);
            return (StackPanel)this.Board.Children[index];
        }
    }
}
