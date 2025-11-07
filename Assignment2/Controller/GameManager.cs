using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using Assignment2.Models.PlayerT.FactoryT;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace Assignment2.Controller
{

    //Get Score, Matrix (to View)
    //playerOneType, playerTwoType, nameOne, nameTwo (to model-Player)
    public class GameManager
    {
        public int[] coordinates { get; set; } = new int[2];
        // Player with black disks starts first
        public event Action<int, int, int> BoardUpdated;
        public Player CurrentPlayer { get; private set; }
        public Factory Player1 { get; } // svart spelare
        public Factory Player2 { get; }
        GameBoard board = new GameBoard();
        public GameManager()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            Factory player1 = new Player1();
            Factory player2 = new Computer();
            
        }
        public void StartGame()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            bool wasMoveMade = false;
            /*Bestäm version på spelare ett och två*/

            //CurrentPlayer = player1;


            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0)
                {
                    CurrentPlayer.RequestMove(validMoves).Wait();

                    /* view gör något för att välja*/
                    //Move moveMade = ; // få det valda draget från view
                    //board.MakeMove(moveMade);
                    
                    SwitchPlayer();
                    //tempBoard = board; 
                    wasMoveMade = true;

                }
                else
                {
                    // no valid moves, skip turn
                    if (!wasMoveMade)
                    {
                        // game over
                        break;
                    }
                    wasMoveMade = false;
                    SwitchPlayer();
                }
                for (int k = 0; k < 8; k++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board.board[k, j] == DiskColor.Black)
                        {
                            currentboard[k, j] = DiskColor.Black;
                        }
                        else if (board.board[k, j] == DiskColor.White)
                        {
                            currentboard[k, j] = DiskColor.White;
                        }
                        else
                        {
                            currentboard[k, j] = DiskColor.Empty;
                        }
                    }
                }
                //BoardUpdated?.Invoke(k, j, );
            }
        }
        private void SwitchPlayer()
        {
            //CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }
      
    }
}

