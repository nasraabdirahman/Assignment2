using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using Assignment2.Models.PlayerT.FactoryT;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2.Controller
{

    //Get Score, Matrix (to View)
    //playerOneType, playerTwoType, nameOne, nameTwo (to model-Player)
    public partial class GameManager
    {
        // Player with black disks starts first
        public Player CurrentPlayer { get; private set; }
        public Factory Player1 { get; } // svart spelare
        public Factory Player2 { get; }

        public GameManager()
        {
            GameBoard board = new GameBoard();
            bool wasMoveMade = false;
            
            Factory player1 = new Player1();
            Factory player2 = new Computer();


            /*Bestäm version på spelare ett och två*/

            CurrentPlayer = (Player?)player1;



            for (int i = 0; i < 60; i++) // i is the current move
            {
                List<Move> validMoves = board.GetValidMoves(CurrentPlayer.diskColor);
                if (validMoves.Count != 0) {
                    CurrentPlayer.RequestMove(validMoves).Wait();

                    /* view gör något för att välja*/
                    //Move moveMade = ; // få det valda draget från view
                    //board.MakeMove(moveMade);
                    // int score = board.GetScore();
                    SwitchPlayer();
                    wasMoveMade = true;
                } else {
                    // no valid moves, skip turn
                    if (!wasMoveMade)
                    {
                        // game over
                        break;
                    }
                    wasMoveMade = false;
                    SwitchPlayer();
                }
            }
        }
        public void SwitchPlayer()
        {
            CurrentPlayer = (Player)((CurrentPlayer == Player1) ? Player2 : Player1);
        }
    }
}

