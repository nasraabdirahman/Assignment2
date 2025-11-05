using System;
using Assignment2.Models.PlayerT;

namespace Assignment2.Models.GameBoard
{
	public class Move
	{
		public int row { get; }
		public int col { get; }
		public DiskColor Player { get; }
		public Move(int row, int col, DiskColor player)
		{
			this.row = row;
			this.col = col;
			this.Player = player;
		}
	}
}