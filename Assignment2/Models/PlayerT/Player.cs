using Assignment2.Models;
using System;
using Assignment2.Models.PlayerT;
using Assignment2.Models.GameBoard;

namespace Assignment2.Models.PlayerT
{
    public abstract class Player
    {
        

        // manually control the tasks that is done
        internal protected TaskCompletionSource<Move>? MoveSource;
        public DiskColor diskColor { get; set; }

        public string Name { get; set; }

        public abstract Task<Move> RequestMove(List<Move> validMoves);


        public Player( string name,DiskColor disk)
        {
            this.diskColor = disk;
            this.Name = name;
        }
    }
}


