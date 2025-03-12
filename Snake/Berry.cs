using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Berry
    {
        public int berryX, berryY;

        public Berry()
        {
            var random = new Random();
            berryX = random.Next(1, GameSettings.windowWidth - 2);
            berryY = random.Next(1, GameSettings.windowHeight - 2);
        }
    }
}
