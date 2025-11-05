using System;
using System.Security.Cryptography.X509Certificates;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT.FactoryT;

namespace Assignment2.Controller
{

    //Get Score, Matrix (to View)
    //playerOneType, playerTwoType, nameOne, nameTwo (to model-Player)
    public partial class GameManager
    {
        // Player with black disks starts first
        public GameManager()
        {
            GameBoard board = new GameBoard();
            
            Factory player1 = new Player1().create("Player 1");
            Factory player2 = new Computer().create("Computer");
            
            bool wasMoveMade = false;
            for (int i = 0; i < 60; i++) // i is the current move
            {
                
            }
        }
    }
}

