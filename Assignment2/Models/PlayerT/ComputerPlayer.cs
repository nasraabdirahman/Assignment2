using Assignment2.Models;
using Assignment2.Models.GameBoard;
using Assignment2.Models.PlayerT;
using System;


namespace Assignment2.Models.PlayerT
{
    public class ComputerPlayer : Player
    {
        private static readonly Random Rand = new Random();
        public ComputerPlayer(string name, DiskColor disk) : base(name, disk)
        {
            this.Name = name;
            this.diskColor = disk;
        }

        public override Task<Move> RequestMove(List<Move> validMoves)
        {
            Task.Delay(1000); // 1 second delay to simulate thinking
            // chooses random move
            int index = Rand.Next(validMoves.Count);
            Move move = validMoves[index];
            return Task.FromResult(validMoves[index]);
        }
    }

}
