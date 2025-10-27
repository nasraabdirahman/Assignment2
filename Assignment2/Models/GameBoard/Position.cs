using System;

public class Position
{
    public int row { get; }
    public int col { get; }
    public Diskcolor color{ get; }
    public Position(int row, int col, Diskcolor color)
    {
        this.row = row;
        this.col = col;
        this.color = color;
    }
}
