using System;
using Assignment2.Player;

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


    // this is to be able to assign a value when the game is over. -1 = white wins. 1 = black wins. 0 = a draw

    internal int Max()
    {
        return 1;
    }

    internal int Min()
    {
        return -1;
    }

    internal int Draw()
    {
        return 0;
    }

    private int Minmax(GameBoard board, int depth, bool maximazingPlayer, int alpha, int beta)
    {
        

        if (board.isGameOver() || depth == 0)
        {

            int[] score = board.GetScore();
            // Black wins
            if (score[0] > score[1])
            {
                return Max();
            }
            // White wins
            if (score[0] < score[1])
            {
                return Min();
            }
            else
            {
                return Draw();
            }
            // tells the player whos turn it is an
            Player currentPlayer;

            if(maximazingPlayer)
            {
                currentPlayer = new HumanPlayer("ai", DiskColor.Black);
            }
            else
            {
                currentPlayer = new HumanPlayer("opponent", DiskColor.White);
            }
                
        }
    }


}
