using System;
using Assignment2.Player;
using Assignment2.PlayerT.FactoryT;

namespace Assignment2.Models.PlayerT.FactoryT
{
    public class Player1 : Factory
    {
    
    public Player create(string name)
    {
        HumanPlayer player1 = new HumanPlayer(Player.DiskColor.Black);
        return player1;
    }
}
