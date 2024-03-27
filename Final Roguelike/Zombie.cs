using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Roguelike
{
    internal class Zombie
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }

        public Zombie(int x, int y)
        {
            X = x;
            Y = y;
            Health = 3;
        }
    }
}
