using Assignment2.Controller;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using System;


namespace Assignment2.Models.PlayerT
{
    public class HumanPlayer : Player
    {
        public string Name;
        private DiskColor disk = new DiskColor();

        public HumanPlayer(string name, DiskColor disk) : base(name, disk) 
        {
            this.Name = name;
            this.disk = disk;
        }

        public override async Task<Move> RequestMove(List<Move> validMoves)
        {
            //create new list of moves 
            MoveSource = new TaskCompletionSource<Move>();
            //wait for the player to click before it can preform any task
            Move move = await MoveSource.Task;
            //check if the move is valid
            if (!validMoves.Exists(m => m.row == move.row && m.col == move.col))
            {
                throw new Exception("Invalid move, Try again!");
            }
            return move;
        }
    }
}


