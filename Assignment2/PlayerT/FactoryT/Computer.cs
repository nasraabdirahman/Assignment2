using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Player;
using Assignment2.PlayerT.FactoryT;

namespace Assignment2.PlayerT.FactoryT
{
    public class Computer : Factory
    {
        public Player.Player create(string name)
        {

            return new ComputerPlayer(name, Player.DiskColor.White);
        }

    }
}
