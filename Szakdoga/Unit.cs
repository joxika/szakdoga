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
        public BitmapImage Image { get; protected set; }
        public GameBoard Board { get; protected set; }

        public int whosturn = 1;
        public abstract bool Lephet(int x, int y);

        public void Lepes(int x, int y)
        {
            
                if (this.PositionX != 0)
                {
                    int oldIndex = (8 - this.PositionY) * 9 + (this.PositionX);
                    ((StackPanel)this.Board.Children[oldIndex]).Children.Clear();
                }

                int index = (8 - y) * 9 + (x);
                var panel = (StackPanel)this.Board.Children[index];
                panel.Children.Clear();
                var img = new Image()
                {
                    Source = this.Image
                };
                img.MouseDown += Img_MouseDown;
                panel.Children.Add(img);

                if (whosturn == 1)
                    whosturn = 0;
                else
                    whosturn = 1;

                this.PositionX = x;
                this.PositionY = y;
           

        }

        private void Img_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Board.ReColor();
            var panel = GetPanel(PositionX, PositionY);

            var value = Colors.White;
            if (whosturn == 1)
            {
                value = Colors.Black;
            }
            else
            {
                value = Colors.White;
            }

            if (value == this.Color)
            {
                this.Board.SelectedUnit = this;
                panel.Background = Brushes.Yellow;

                for (int x = 1; x <= 8; x++)
                {
                    for (int y = 1; y <= 8; y++)
                    {
                        if (Lephet(x, y))
                        {
                            GetPanel(x, y).Background = Brushes.Red;
                        }
                    }
                }

                
            }
            }

        protected StackPanel GetPanel(int x, int y)
        {
            return Board.GetPanel(x, y);
        }
    }
}
