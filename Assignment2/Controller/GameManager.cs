using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Assignment2.Controller
{

    //Get Score, Matrix (to View)
    //playerOneType, playerTwoType, nameOne, nameTwo (to model-Player)
    public class GameManager
    {
        public int[] coordinates { get; set; } = new int[3];
        // Player with black disks starts first
        public event Action<int, int, int> BoardUpdated;
        public Player CurrentPlayer { get; private set; }
        public Player p1 { get; set; }
        public Player p2 { get; set; }

        GameBoard board = new GameBoard();
        public GameManager()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            
        }
        public void StartGame()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            bool wasMoveMade = false;
            

            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0)
                {
                    
                    Move moveMade = CurrentPlayer.RequestMove(validMoves).Wait();
                    board.MakeMove(moveMade);

                    SwitchPlayer();
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
                /*for (int k = 0; k < 8; k++)
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
                //BoardUpdated?.Invoke(k, j, );*/
                Window1 w1 = new Window1();
                w1.Show();
            }
        }
        private void SwitchPlayer()
        {
            //CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }
      
    }
}

