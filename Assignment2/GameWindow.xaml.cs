using Assignment2.Controller;
using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
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
        GameManager manager = new GameManager(); 
        public GameGrid GameGrid = new GameGrid();
        public Player p1 {  get; set; }
        public Player p2 { get; set; }

        public GameWindow() 
        { 
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }
        public void StartGame_Clicked(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            SetupGameDialog sDialog= new SetupGameDialog();
            GameGrid gg = new GameGrid();
            GameBoard gb = new GameBoard();

            sDialog.gameSetup += setUpComplete;
            sDialog.ShowDialog();

            player1.Text = sDialog.nameOne;
            player2.Text = sDialog.nameTwo;
            player1NumOfTokens.Text = Convert.ToString(gb.GetTeamScore(DiskColor.Black)) ;
            player2NumOfTokens.Text = Convert.ToString(gb.GetTeamScore(DiskColor.White)) ;

            Grid.SetColumn(GameGrid, 4);
            Grid.SetRowSpan(GameGrid, 6);

            GameWindowGrid.Children.Add(GameGrid);
            manager.p1 = this.p1;
            manager.p2 = this.p2;
            manager.StartGame();
        }
        public void setUpComplete(string name1, string name2, string type1, string type2)
        {
            if (type1 == "Human Player")
            {
                p1 = new HumanPlayer(name1, DiskColor.Black);
            }
            else
            {
                p1 = new ComputerPlayer(name1, DiskColor.Black);
            }
            if (type2 == "Human Player")
            {
                p2 = new HumanPlayer(name2, DiskColor.White);
            }
            else 
            {
                p2 = new ComputerPlayer(name2, DiskColor.White);
            }
        }

        public void updateTokenSum(int black, int white)
        {
            player1NumOfTokens.Text = Convert.ToString(black) ;
            player2NumOfTokens.Text = Convert.ToString(white);
        }
        
        public void newGame()
        {
            //GameWindowGrid.Children.Remove(board);
            GameWindowGrid.Children.Clear();
        }
    }
}