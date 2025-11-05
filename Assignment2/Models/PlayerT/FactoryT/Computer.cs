using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.PlayerT;
using Assignment2.Models.PlayerT.FactoryT;

namespace Assignment2.Models.PlayerT.FactoryT
{
    public class Computer : Factory
    {
        public Player create(string name, DiskColor disk)
        {

            return new ComputerPlayer(name, disk);
        }

    }
}
