using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Player.MinMax
{
    class Terminal
    {
        // this is to be able to assign a value when the game is over. -1 = white wins. 1 = black wins. 0 = a draw
        internal int Max()
        {
            return 1;
        }

        internal int Min()
        {
            return -1;
        }

        internal int Draw()
        {
            return 0;
        }
    }
}
