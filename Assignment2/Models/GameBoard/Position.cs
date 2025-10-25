using System;

public class Position
{
    public int row { get; }
    public int col { get; }
    public Diskcolor color{ get; }
    public Position(int row, int col, Diskcolor color)
    {
        Row = row;
        Col = col;
        Color = color;
    }
}
