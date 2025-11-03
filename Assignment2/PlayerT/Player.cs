using Assignment2.Models;
using System;


namespace Assignment2.Player
{
    public abstract class Player
    {
        

        // manually control the tasks that is done
        internal protected TaskCompletionSource<Move>? MoveSource;
        public DiskColor diskColor { get; set; }

        public string Name { get; set; }

        public abstract Task<Move> RequestMove(GameBoard board, List<Move> validMoves);


        public Player( string name,DiskColor disk)
        {
            this.diskColor = disk;
            this.Name = name;
        }
    }
}


