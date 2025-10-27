using System;

public class ComputerPlayer : Player
{

    public ComputerPlayer(string name, DiskColor disk) : base(name, disk)
    {
    }

    //not fully implimented
    public override async Task<Move> RequestMove(GameBoard board, List<Move> validMoves)
    {
        MoveSource = new TaskCompletionSource<Move>();
        Move move = await MoveSource.Task;

        return move;
    }

    public Move
}
