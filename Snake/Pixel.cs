using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor? color { get; set; }

        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
