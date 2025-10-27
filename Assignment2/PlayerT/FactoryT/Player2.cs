using System;

internal class Player2 : PlayerFactory
{

    public Player create(string name)
    {
        return new HumanPlayer(name, Player.DiskColor.White);
    }
}
