using System;
using Assignment2.Player;
using Assignment2.Models.GameBoard;
using Assignment2.Models;


  public class ComputerPlayer : Player
{
    private static readonly Random Rand = new Random();
    public ComputerPlayer(string name, DiskColor disk) : base(name, disk)
    {
        this.diskColor = disk;
    }

    public override async Task<Move> RequestMove(GameBoard board, List<Move> validMoves)
    {
        await Task.Delay(1000); // 1 second delay to simulate thinking

        // if the move isnt valid reeturn null;

        if(validMoves == null || validMoves.Count == 0)
        {
            return null;
        }
        // chooses random move
        int index = Rand.Next(validMoves.Count);
        Move move = validMoves[index];
        return move;
    }
}
