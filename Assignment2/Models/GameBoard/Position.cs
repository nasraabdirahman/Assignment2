using System;
using Assignment2.Player;

namespace Assignment2.Models.GameBoard
{
    public class Position
    {
        public int row { get; }
        public int col { get; }
        public DiskColor color { get; }
        public Position(int row, int col, DiskColor color)
        {
            this.row = row;
            this.col = col;
            this.color = color;
        }
    }
}