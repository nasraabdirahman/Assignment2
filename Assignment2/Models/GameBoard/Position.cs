using System;
using Assignment2.Models.PlayerT;

namespace Assignment2.Models.GameBoard
{
    public class Position
    {
        public int row { get; }
        public int col { get; }
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}