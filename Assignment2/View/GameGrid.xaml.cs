using Assignment2.Controller;
using Assignment2.Models.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment2.View
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        public GameManager manager { get; set; }

        public GameGrid()
        {
            InitializeComponent();
            Token("Black", 4, 5);
            Token("Black", 5, 4);
            Token("White", 4, 4);
            Token("White", 5, 5);
        }
        public void Token(string colour, int x, int y)
        {
            if (colour == "Black")
            {
                Ellipse tokenB = new Ellipse
                {
                    Width = 90,
                    Height = 90,
                    Fill = Brushes.Black,
                };
                MyGrid.Children.Add(tokenB);
                Grid.SetRow(tokenB, x);
                Grid.SetColumn(tokenB, y);
            }
            else if (colour == "White")
            {
                Ellipse tokenW = new Ellipse
                {
                    Width = 90,
                    Height = 90,
                    Fill = Brushes.White,
                };
                MyGrid.Children.Add(tokenW);
                Grid.SetRow(tokenW, x);
                Grid.SetColumn(tokenW, y);
            }
            return;
        }
        public void ChangeColour(string colour, int x, int y)
        {
            foreach (Ellipse token in MyGrid.Children.OfType<Ellipse>())
            {
                if (Grid.GetRow(token) == x && Grid.GetColumn(token) == y)
                {
                    if (colour == "White")
                    {
                        token.Fill = Brushes.Black;
                    }
                    else
                    {
                        token.Fill = Brushes.White;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Token("Black", Grid.GetRow(button), Grid.GetColumn(button));

            manager.coordinates[0] = Grid.GetRow(button)-1;
            manager.coordinates[1] = Grid.GetColumn(button)-1 ;
        }
    }
}
