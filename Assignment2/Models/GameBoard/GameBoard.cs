using System;

public class GameBoard
{
	public Diskcolor[,] board { get; private set; } = new Diskcolor[8,8];
    public GameBoard()
	{
		InitializeBoard();
	}
	private void InitializeBoard()
	{
		foreach(Diskcolor in board)
		{
			Diskcolor = Diskcolor.Empty;
        }
		board[3,3] = Diskcolor.White;
		board[3,4] = Diskcolor.Black;
		board[4,3] = Diskcolor.Black;
		board[4,4] = Diskcolor.White;
    }
    public List<Move> GetValidMoves(Player currentPlayer)
	{
        List<Move> validMoves = new list<Move>(); // will be returned
		Diskcolor curcolor = currentPlayer.diskColor; // current player's color
        Diskcolor opcolor = (curcolor == Diskcolor.Black) ? Diskcolor.White : Diskcolor.Black; // opponent's color
        List<Move> candidatemoves = new List<Move>(); // all potential moves 
		for(int row = 0; row < 8; row++) // used to find all potential moves
        {
			for(int col = 0; col < 8; col++)
			{
				
            }
        }

        return validMoves;
    }
	private List<Position> Touches(Position position)
	{
		List<Position> surrounding = new List<Position>();
		int row = position.row;
		int col = position.col;
		int[] dir = {-1, 0, 1};
		int boardSize = 8;

        foreach (int drow in dir)
		{
			foreach(int dcol in dir)
			{
				if(drow == 0 && dcol == 0) // check for center
				{ 
					continue; 
				}
				// new position
                int newRow = row + drow;
                int newCol = col + dcol;
                // check for out of bounds
                if (newRow >= 0 && newRow < boardSize && newCol >= 0 && newCol < boardSize)
                {
                    surrounding.Add(new Position(newRow, newCol, board[newRow,newCol])); // add to return list
                }
            }
        }
		return surrounding;
    }
	private bool IsMoveValid() // move through all directions until one is valid else return false
    { 

	}
	public void MakeMove() // updates board
	{

	}
	public int[] GetScore() // returns score as two ints
	{
    }
}
