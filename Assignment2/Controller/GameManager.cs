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
        public object MoveSource { get; internal set; }

        public GameGrid GameGrid {  get; set; }
        GameBoard board = new GameBoard();
        public async void StartGame()
        {
            CurrentPlayer = p1;
            DiskColor[,] currentboard = new DiskColor[8, 8];
            bool wasMoveMade = false;
            

            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0)
                {
                    Move moveMade = await CurrentPlayer.RequestMove(validMoves);
                    board.MakeMove(moveMade);
                    Position chosenMove = new Position( coordinates[0], coordinates[1]);
                    GameGrid.Token(Convert.ToString(CurrentPlayer.diskColor), chosenMove.row + 1, chosenMove.col + 1);
                    SwitchPlayer();
                    wasMoveMade = true;

                }
                else
                {
                    // no valid moves, skip turn
                    if (!wasMoveMade)
                    {
                        Result();
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
                            GameGrid.ChangeColour("Black", k+1, j+1);
                        }
                        else if (board.board[k, j] == DiskColor.White)
                        {
                            currentboard[k, j] = DiskColor.White;
                            GameGrid.ChangeColour("White", k+1, j+1);
                        }
                        else
                        {
                            currentboard[k, j] = DiskColor.Empty;
                        }
                        //BoardUpdated?.Invoke(k, j, (int)board.board[k, j];
                    }

                }
  
            }
        }
        private void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == p1) ? p2 : p1;
        }
      
        public void Result()
        {
            if (board.GetTeamScore(DiskColor.White) > board.GetTeamScore(DiskColor.Black))
            {
                WinnerDialog WD = new WinnerDialog(board.GetTeamScore(DiskColor.White), p2.Name);
                WD.Show();
            }
            else if (board.GetTeamScore(DiskColor.White) < board.GetTeamScore(DiskColor.Black))
            {
                WinnerDialog WD = new WinnerDialog(board.GetTeamScore(DiskColor.Black), p1.Name);
                WD.Show();
            }
            else if (board.GetTeamScore(DiskColor.White) == board.GetTeamScore(DiskColor.Black))
            {
                DrawDialog drawDialog = new DrawDialog(board.GetTeamScore(DiskColor.White));
                drawDialog.Show();
            }
            return;
        }
    }
}

