using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Szakdoga
{
    public class GameBoard: UniformGrid
    {
        public GameBoard()
        {
            this.Rows = 9;
            this.Columns = 9;

            for (int j = 8; j > 0; j--)
            {
                Label label = new Label()
                {
                    Content = j.ToString(),
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                };
                this.Children.Add(label);

                for (int i = 0; i < 8; i++)
                {
                    this.Children.Add(new StackPanel()
                    {
                        Background = (i + j) % 2 == 0 ? Brushes.Gray : Brushes.LightGray
                    });
                }
            }
            this.Children.Add(new StackPanel());

            for (char i = 'A'; i <= 'H'; i++)
            {
                this.Children.Add(new Label()
                {
                    Content = i,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                });
            }
        }
        public void ReColor()
        {
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    GetPanel(x, y).Background = (x + y) % 2 == 1 ? Brushes.Gray : Brushes.LightGray;
                }
            }
        }

        protected StackPanel GetPanel(int x, int y)
        {
            int index = (8 - y) * 9 + (x);
            return (StackPanel)this.Children[index];
        }
    }
}
