using Assignment2.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        
        public void StartGame_Clicked(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            SetupGameDialog Sdialog= new SetupGameDialog();
            GameGrid gg = new GameGrid();
            Sdialog.ShowDialog();

            player1.Text = Sdialog.nameOne;
            player2.Text = Sdialog.nameTwo;
            player1NumOfTokens.Text = "2" ;
            player2NumOfTokens.Text = "2" ;
            gg.ShowDialog();
        }
        public void UpdateTokens(int black, int white)
        {
            player1NumOfTokens.Text = Convert.ToString(black) ;
            player2NumOfTokens.Text = Convert.ToString(white);
        }
    }
}