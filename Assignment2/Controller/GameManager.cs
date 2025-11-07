using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using Assignment2.Models.PlayerT.FactoryT;
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
        public int[] coordinates { get; set; } = new int[2];
        // Player with black disks starts first
        public event Action<int, int, int> BoardUpdated;
        public Player CurrentPlayer { get; private set; }
        public Factory p1 { get; }
        public Factory p2 { get; }

        GameBoard board = new GameBoard();
        public GameManager()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            
        }
        public void StartGame()
        {
            Window1 w1 = new Window1();
            w1.Show();
            DiskColor[,] currentboard = new DiskColor[8, 8];
            bool wasMoveMade = false;
            

            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0)
                {
                    CurrentPlayer.RequestMove(validMoves).Wait();
                    // Move moveMade =
                    //board.MakeMove(moveMade);

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
                }*/
                //BoardUpdated?.Invoke(k, j, );
            }
        }
        private void SwitchPlayer()
        {
            //CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }
      
    }
}

