using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Szakdoga

{
    public class GameBoard : UniformGrid
    {
        public Unit SelectedUnit { get; set; }

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
                    var panel = new StackPanel()
                    {
                        Background = (i + j) % 2 == 0 ? Brushes.LightGray : Brushes.Gray
                    };
                    panel.MouseDown += Panel_MouseDown;
                    this.Children.Add(panel);
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

        private void Panel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            var panel = (StackPanel)sender;
            var index = this.Children.IndexOf(panel);
            var x = index % 9;
            var y = 8 - (index / 9);
            //if (SelectedUnit != null)
            //{
                if (SelectedUnit.Lephet(x, y))
                {
                    SelectedUnit.Lepes(x, y);
                    ReColor();
                    SelectedUnit = null;
                }
           // }
        }

        public void ReColor()
        {
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    GetPanel(x, y).Background = (x + y) % 2 == 1 ? Brushes.LightGray : Brushes.Gray;
                }
            }
        }

        public StackPanel GetPanel(int x, int y)
        {
            int index = (8 - y) * 9 + (x);
            return (StackPanel)this.Children[index];
        }

    }
}
