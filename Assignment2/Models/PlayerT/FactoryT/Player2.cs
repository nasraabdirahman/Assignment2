using Assignment2.Player;
using Assignment2.PlayerT.FactoryT;
using System;

internal class Player2 : Factory
{

    public Player create(string name)
    {
        HumanPlayer player2 = new HumanPlayer( Player.DiskColor.White);
        return player2;
    }
}
