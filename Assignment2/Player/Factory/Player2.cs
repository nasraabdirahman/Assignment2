using System;

internal class Player2 : Factory
{

    public HumanPlayer create(string name)
    {
        return new HumanPlayer(name, Player.DiskColor.White);
    }
}
