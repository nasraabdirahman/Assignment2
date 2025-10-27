using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Player;

namespace Assignment2.FactoryT
{
    internal interface Factory
    {
        public Player.Player create(string name);
    }
}
