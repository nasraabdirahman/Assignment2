using Assignment2.Controller;
using Assignment2.Models.GameBoard;
using Assignment2.Models;
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
        public GameManager _manager; 
        internal GameGrid board = new Assignment2.View.GameGrid();
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
            sDialog.ShowDialog();

            sDialog.gameSetup += setUpComplete;

            player1.Text = sDialog.nameOne;
            player2.Text = sDialog.nameTwo;
            player1NumOfTokens.Text = Convert.ToString(gb.GetTeamScore(DiskColor.Black)) ;//Change to get Score
            player2NumOfTokens.Text = Convert.ToString(gb.GetTeamScore(DiskColor.White)) ;

            Grid.SetColumn(board, 4);
            Grid.SetRowSpan(board, 6);
            GameWindowGrid.Children.Add(board);
        }
        public void setUpComplete(string name1, string name2, string type1, string type2)
        {


        }

        public void updateTokens(int black, int white)
        {
            player1NumOfTokens.Text = Convert.ToString(black) ;
            player2NumOfTokens.Text = Convert.ToString(white);
        }
        public void startGame()
        {
            GameManager gm = new GameManager();
            gm.StartGame();
        }
        
        public void newGame()
        {
            //GameWindowGrid.Children.Remove(board);
            GameWindowGrid.Children.Clear();
        }
    }
}