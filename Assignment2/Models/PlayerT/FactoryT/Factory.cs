using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.PlayerT;

namespace Assignment2.Models.PlayerT.FactoryT
{
    public interface Factory
    {
        public Player create(string name);
    }
}
