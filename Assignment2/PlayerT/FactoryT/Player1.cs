using System;
using Assignment2.Player;
using Assignment2.PlayerT.FactoryT;

public class Player1 : Factory
{

    public Player create(string name)
    {
        HumanPlayer player1 = new HumanPlayer(name, Player.DiskColor.Black);
        return player1;
    }
}
