using Assignment2.Models.PlayerT;
using System;
using Assignment2.Models.PlayerT.FactoryT;

namespace Assignment2.Models.PlayerT.FactoryT
{
    internal class Player2 : Factory
    {
        public Player create(string name, DiskColor disk)
        {
            HumanPlayer player2 = new HumanPlayer(name, disk);
            return player2;
        }
    }


}
