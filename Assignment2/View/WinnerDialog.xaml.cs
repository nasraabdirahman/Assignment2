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
    /// Interaction logic for WinnerDialog.xaml
    /// </summary>
    public partial class WinnerDialog : Window
    {
        public WinnerDialog(int tokenCount, string name)
        {
            InitializeComponent();
            Name.Text = name;
            winnerTokens.Text = $"You won, with {tokenCount} tokens";
        }
        public void newGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //GameWindow.newGame();
        }
    }
}
