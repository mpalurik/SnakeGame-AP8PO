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

        public Berry(GameState gameState)
        {
            var random = new Random();
            bool isBerryColliding;

            do
            {
                berryX = random.Next(1, GameSettings.windowWidth - 2);
                berryY = random.Next(1, GameSettings.windowHeight - 2);

                isBerryColliding = false;

                foreach (var snake in gameState.Snakes)
                {
                    if (berryX == snake.head.X && berryY == snake.head.Y)
                    {
                        isBerryColliding = true;
                        break;
                    }

                    foreach (var pixel in snake.body)
                    {
                        if (pixel.X == berryX && pixel.Y == berryY)
                        {
                            isBerryColliding = true;
                            break;
                        }
                    }

                    if (isBerryColliding)
                    {
                        break;
                    }
                }
            } while (isBerryColliding);
        }
    }
}
