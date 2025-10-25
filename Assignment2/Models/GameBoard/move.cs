using System;

public class Move
{
	public int row { get;}
    public int col { get;}
	public Player Player {get;}
    public Move(int row, int col, Player player)
	{
		Row = row;
		Col = col;
		Player = curPlayer;
    }
}