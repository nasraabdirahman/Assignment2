using System;
using Assignment2.Player;
public class HumanPlayer : Player
{
    public HumanPlayer(string name, DiskColor disk) : base( name,disk)
    {
    }

    public override async Task<Move> RequestMove(GameBoard board, List<Move> validMoves)
    {
        //create new list of moves 
        MoveSource = new TaskCompletionSource<Move>();
        //wait for the player to click before it can preform any task
        Move move = await MoveSource.Task;
        //check if the move is valid
        if(!validMoves.Exists(m=>m.row == move.row && m.col == move.col))
        {
            throw new Exception("Invalid move, Try again!");
        }
        return move;
    }
}

