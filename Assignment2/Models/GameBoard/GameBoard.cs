using System;
using Assignment2.Controller;
using Assignment2.Models.PlayerT;
using System.Collections.Generic;


namespace Assignment2.Models.GameBoard {

	public class GameBoard
	{

		private const int BoardSize = 8;
		public DiskColor[,] board { get; private set; } = new DiskColor[BoardSize, BoardSize];
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
			board[3, 3] = DiskColor.White;
			board[3, 4] = DiskColor.Black;
			board[4, 3] = DiskColor.Black;
			board[4, 4] = DiskColor.White;
		}
		public List<Move> GetValidMoves(DiskColor currentPlayer)
		{
			List<Move> validMoves = new List<Move>(); // will be returned
			DiskColor curcolor = currentPlayer; // current player's color
			DiskColor opcolor = (curcolor == DiskColor.Black) ? DiskColor.White : DiskColor.Black; // opponent's color
			List<Position> candidatemoves = new List<Position>(); // all potential moves 
			for (int row = 0; row < BoardSize; row++) // used to find all potential moves
			{
				for (int col = 0; col < BoardSize; col++)
				{
					if (board[row, col] == opcolor) // this optimizes the search for valid moves slightly
					{
                        Position tempcurrent = new Position(row, col); // add the candidate moves
                                                                       //candidatemoves.Add(Touches(tempcurrent));
                        List<Position> candidmoves = Touches(tempcurrent);
                        foreach (var move in candidmoves)
                        {
                            candidatemoves.Add(move);
                        }
                    }
				}
			}
			foreach (Position pos in candidatemoves) // check each candidate move for validity
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
			int[] dir = { -1, 0, 1 };

			foreach (int drow in dir)
			{
				foreach (int dcol in dir)
				{
					if (drow == 0 && dcol == 0) // check for center
					{
						continue;
					}
					// new position
					int newRow = row + drow;
					int newCol = col + dcol;
					// check for out of bounds
					if (newRow >= 0 && newRow < BoardSize && newCol >= 0 && newCol < BoardSize)
					{
						surrounding.Add(new Position(newRow, newCol)); // add to return list
					}
				}
			}
			return surrounding;
		}
		private bool IsMoveValid(Position position, DiskColor player) // move through all directions until one is valid else return false
		{
			if (board[position.row, position.col] != DiskColor.Empty) // if not empty return false
			{
				return false;
			}

			int[] dir = { -1, 0, 1 }; // go through all directions
			foreach (int drow in dir) // until one is valid
			{
				foreach (int dcol in dir)
				{
					if (drow == 0 && dcol == 0) // check for center
					{
						continue;
					}
					if (ProcessLine(GetLine(position, drow, dcol), player))
					{
						return true; // valid move found
					}

				}
			}
			return false;
		}
		private List<Position> GetLine(Position start, int dRow, int dCol)
		{
			List<Position> line = new List<Position>();
			int row = start.row + dRow;
			int col = start.col + dCol;

			while (row >= 0 && row < 8 && col >= 0 && col < 8)
			{
				line.Add(new Position(row, col));
				row += dRow;
				col += dCol;
			}
			return line;
		}
        private bool ProcessLine(List<Position> line, DiskColor player)
        {
            DiskColor op = (player == DiskColor.Black) ? DiskColor.White : DiskColor.Black;
            bool seenOpponent = false;

            foreach (var p in line)
            {
                DiskColor cell = board[p.row, p.col];   // correct order: [row, col]

                if (cell == DiskColor.Empty)
                    return false;                       // gap → not a capture line

                if (cell == op)
                {
                    seenOpponent = true;                // keep scanning
                    continue;
                }

                // cell == player
                return seenOpponent;                    // valid only if at least one opponent in between
            }

            return false; // reached edge without hitting own disk
        }
        public void MakeMove(Move move) // updates board
		{
			DiskColor diskColor = move.Player;


			Position currentpos = new Position(move.row, move.col);
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
						foreach (Position pos in curdir) // go through the line
						{
							if (board[pos.row, pos.col] == diskColor) // already know the line is valid
							{
								break; // stop when you hit your own disk
							}
							board[pos.row, pos.col] = diskColor; // change the color
						}
					}
				}
			}
			board[move.row, move.col] = diskColor; // place the new disk
		}
		
        public int GetTeamScore(DiskColor team) 
        {
            int score = 0;
            foreach (DiskColor disk in board)
            {
                if (disk == team)
                {
                    score++;
                }
            }
            return score; 
        }
    }
}