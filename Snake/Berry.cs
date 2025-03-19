using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Berry
    {
        public Pixel berryPixel;

        public Berry(GameState gameState)
        {
            berryPixel = new Pixel(0, 0);
            var random = new Random();
            bool isBerryColliding;

            do
            {
                berryPixel.X = random.Next(1, GameSettings.windowWidth - 2);
                berryPixel.Y = random.Next(1, GameSettings.windowHeight - 2);

                isBerryColliding = false;

                foreach (var snake in gameState.Snakes)
                {
                    if (berryPixel == snake.head)
                    {
                        isBerryColliding = true;
                        break;
                    }

                    foreach (var snakePixel in snake.body)
                    {
                        if (snakePixel == berryPixel)
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
