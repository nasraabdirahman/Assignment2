using System;

public class GameBoard
{
    private const int BoardSize = 8;
    public DiskColor[,] board { get; private set; } = new DiskColor[BoardSize,BoardSize];
    public GameBoard()
	{
		InitializeBoard();
	}
	private void InitializeBoard()
	{
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                board[row, col] = DiskColor.Empty;
            }
        }
        board[3,3] = DiskColor.White;
		board[3,4] = DiskColor.Black;
		board[4,3] = DiskColor.Black;
		board[4,4] = DiskColor.White;
    }
    public List<Move> GetValidMoves(Player currentPlayer)
	{
        List<Move> validMoves = new List<Move>(); // will be returned
		DiskColor curcolor = currentPlayer.DiskColor; // current player's color
        DiskColor opcolor = (curcolor == DiskColor.Black) ? DiskColor.White : DiskColor.Black; // opponent's color
        List<Position> candidatemoves = new List<Move>(); // all potential moves 
		for(int row = 0; row < BoardSize; row++) // used to find all potential moves
        {
			for(int col = 0; col < BoardSize; col++)
			{
				if(board[row,col] == DiskColor.opcolor) // this optimizes the search for valid moves slightly
                {
					Position tempcurrent = new Position(row, col, board[row,col]); // add the candidate moves
                    candidatemoves.Add(Touches(tempcurrent));
				}
            }
        }
		foreach(Position pos in candidatemoves) // check each candidate move for validity
		{
			if (IsMoveValid(pos, currentPlayer)) // if valid add to return list
			{
				Move tempMove = new Move(pos.row, pos.col, currentPlayer);
				validMoves.Add(tempMove);
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
                if (newRow >= 0 && newRow < BoardSize && newCol >= 0 && newCol < BoardSize)
                {
                    surrounding.Add(new Position(newRow, newCol, board[newRow,newCol])); // add to return list
                }
            }
        }
		return surrounding;
    }
	private bool IsMoveValid(Position position, Player player) // move through all directions until one is valid else return false
    {
		if(board[position.row, position.col] != DiskColor.Empty) // if not empty return false
		{
			return false;
		}

		int[] dir = {-1, 0, 1}; // go through all directions
        foreach (int drow in dir) // until one is valid
		{
			foreach(int dcol in dir)
			{
                if (drow == 0 && dcol == 0) // check for center
                {
                    continue;
                }
				if(ProcessLine(GetLine(position,drow,dcol),player)
				{
					return true; // valid move found
                }

            }
        }
    }
    private List<Position> GetLine(Position start, int dRow, int dCol)
    {
        List<Position> line = new List<Position>();
        int row = start.Row + dRow;
        int col = start.Col + dCol;

        while (row >= 0 && row < 8 && col >= 0 && col < 8)
        {
            line.Add(new Position(row, col, board[row, col]));
            row += dRow;
            col += dCol;
        }

        return line;
    }
	private bool ProcessLine(List<Position> line, Player player)
	{
		DiskColor currcolor = player.DiskColor;
		DiskColor opcolor = (currcolor == DiskColor.Black) ? DiskColor.White : DiskColor.Black;
		if (line.Count < 2) // quick check for too short distances
		{
			return false;
		}
        
		int index = 0;
        while (index < line.Count) // go through line 
		{
			if(line[index].color == DiskoColor.Empty) // empty means invalid
            {
				return false;
			}
			else if(line[index].color == currcolor) // if we hit our color
            {										// check previous 
				if (index > 0 && line[index - 1].Color == opColor) // if we have atleast one op then valid
				{
					return true;
				}
                else // else invalid
                {
					return false;
				}
			}
			index++; // move to next position
        }
		return false; // if we finish the loop without returning then return false
    }
    public void MakeMove(Move move) // updates board
	{
		DiskColor diskColor = move.Player.DiskColor

        Position currentpos = new Position(move.row, move.col, board[move.row, move.col]);
        int[] dir = { -1, 0, 1 };
		foreach (int drow in dir)
		{
			foreach (int dcol in dir)
			{
                if (drow == 0 && dcol == 0) // center check
                    continue;

                List<Position> curdir = GetLine(currentpos, drow, dcol);
				if (ProcessLine(curdir, move.Player))
				{           // we flip the disks
					foreach(Position pos in curdir) // go through the line
                    {
						if (board[pos.Row, pos.Col] == diskColor) // already know the line is valid
						{
							break; // stop when you hit your own disk
						}
						board[pos.Row, pos.Col] = diskColor; // change the color
					}
                }
            }
        }
		board[move.row, move.col] = diskColor; // place the new disk
    }
    public int[] GetScore() // returns score as two ints
	{
		int blackScore = 0;
		int whiteScore = 0;
		foreach(Diskcolor disk in board)
		{
			if(Diskcolor == Diskcolor.Black)
			{
				blackScore++;
			}
			else if(Diskcolor == Diskcolor.White)
			{
				whiteScore++;
			}
        }
		return new int[] {blackScore, whiteScore}; // returns scores as [blackScore, whiteScore]
    } 
}
