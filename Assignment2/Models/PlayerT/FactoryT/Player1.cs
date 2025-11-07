using System;
using Assignment2.Models.PlayerT;
using Assignment2.Models.PlayerT.FactoryT;

namespace Assignment2.Models.PlayerT.FactoryT
{
    public class Player1 : Factory
    {
        public Player create(string name, DiskColor disk)
        {
            HumanPlayer player = new HumanPlayer(name, disk);
            return player;
        }
    }
}

