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
        private Random random;

        public Berry()
        {
            random = new Random();
        }

        private void SpawnBerry()
        {
            berryX = random.Next(1, WindowWidth - 2);
            berryY = random.Next(1, WindowHeight - 2);
        }

    }
}
