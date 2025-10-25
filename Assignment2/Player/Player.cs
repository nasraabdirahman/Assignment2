using System;

public abstract class Player
{
    public enum DiskColor { White, Black }

    // manually control the tasks that is done
    internal protected TaskCompletionSource<Move>? MoveSource;
    public DiskColor diskColor { get; set; }

    public abstract Task<Move> RequestMove(GameBoard board, List<Move> validMoves);
}
