using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;
using System.Collections.Generic;
using Assignment2.View;

namespace Assignment2.Controller
{

    //Get Score, Matrix (to View)
    //playerOneType, playerTwoType, nameOne, nameTwo (to model-Player)
    public class GameManager
    {
        public int[] coordinates { get; set; } = new int[2];
        // Player with black disks starts first
        public Player CurrentPlayer { get; private set; }
        public Player p1 { get; set; }
        public Player p2 { get; set; }

        GameBoard board = new GameBoard();
        public GameManager()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            
        }
        public async void StartGame()
        {
            DiskColor[,] currentboard = new DiskColor[8, 8];
            bool wasMoveMade = false;
            GameGrid gg = new GameGrid();
            

            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0)
                {
                    
                    Move moveMade = await CurrentPlayer.RequestMove(validMoves);
                    board.MakeMove(moveMade);
                    gg.Token(Convert.ToString(moveMade.Player), moveMade.row +1, moveMade.col +1);
                    Position chosenMove = new Position( coordinates[0], coordinates[1]);
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
                for (int k = 0; k < 8; k++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board.board[k, j] == DiskColor.Black)
                        {
                            currentboard[k, j] = DiskColor.Black;
                            gg.ChangeColour("Black", k+1, j+1);
                        }
                        else if (board.board[k, j] == DiskColor.White)
                        {
                            currentboard[k, j] = DiskColor.White;
                            gg.ChangeColour("White", k+1, j+1);
                        }
                        else
                        {
                            currentboard[k, j] = DiskColor.Empty;
                        }
                    }
                }
                Window1 w1 = new Window1();
                w1.Show();
            }
        }
        private void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == p1) ? p2 : p1;
        }
      
    }
}

