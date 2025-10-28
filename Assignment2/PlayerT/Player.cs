using System;


namespace Assignment2.Player
{
    public abstract class Player
    {
        public enum DiskColor { White, Black }

        // manually control the tasks that is done
        internal protected TaskCompletionSource<Move>? MoveSource;
        public DiskColor diskColor { get; set; }

        public string Name { get; set; }

        public abstract Task<Move> RequestMove(GameBoard board, List<Move> validMoves);


        public Player(string name, DiskColor disk)
        {
            this.Name = name;
            this.diskColor = disk;
        }
    }
}


