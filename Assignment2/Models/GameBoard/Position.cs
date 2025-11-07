using System;
using Assignment2.Models.PlayerT;

namespace Assignment2.Models.GameBoard
{
    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}