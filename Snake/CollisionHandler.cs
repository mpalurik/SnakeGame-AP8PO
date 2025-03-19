using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    enum CollisionType
    {
        BERRY,
        BORDER,
        SNAKE,
        NONE
    }

    class CollisionHandler
    {
        public CollisionType CheckCollisions(GameState gameState)
        {
            for (int i = 0; i < gameState.Snakes.Count; i++)
            {
                var snake = gameState.Snakes[i];
                if (snake.head.X == 0 || snake.head.X == GameSettings.windowWidth - 1 || snake.head.Y == 0 || snake.head.Y == GameSettings.windowHeight - 1)
                {
                    HandleBorderCollision(gameState);
                    return CollisionType.BORDER;
                }
                foreach (var pixel in snake.body)
                {
                    if (pixel == snake.head)
                    {
                        HandleSnakeCollision(gameState);
                        return CollisionType.SNAKE;
                    }
                }
                for (int j = 0; j < gameState.Berries.Count; j++)
                {
                    if (snake.head == gameState.Berries[j].berryPixel)
                    {
                        HandleBerryCollision(gameState, i, j);
                        return CollisionType.BERRY;
                    }
                }
            }
            return CollisionType.NONE;
        }

        private void HandleBerryCollision(GameState gameState, int snakeIndex, int berryIndex)
        {
            gameState.Snakes[snakeIndex].score++;
            gameState.Berries.RemoveAt(berryIndex);
            gameState.Berries.Add(new Berry(gameState));
        }

        private void HandleBorderCollision(GameState gameState)
        {
            gameState.isGameOver = true;
            // Handle border collision logic here
            Console.WriteLine("Border collision detected!");
        }

        private void HandleSnakeCollision(GameState gameState)
        {
            gameState.isGameOver = true;
            // Handle snake collision logic here
            Console.WriteLine("Snake collision detected!");
        }
    }
}
