using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class RenderHandler
    {
        public void RenderBorders()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < GameSettings.windowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, GameSettings.windowHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < GameSettings.windowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(GameSettings.windowWidth - 1, i);
                Console.Write("■");
            }
        }

        public void RenderSnakes(List<Snake> snakes)
        {
            foreach (var snake in snakes)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (Pixel pixel in snake.body)
                {
                    Console.SetCursorPosition(pixel.X, pixel.Y);
                    Console.Write("■");
                }
                Console.SetCursorPosition(snake.head.X, snake.head.Y);
                Console.ForegroundColor = snake.color;
                Console.Write("■");
            }
        }

        public void RenderBerries(List<Berry> berries)
        {
            foreach (var berry in berries)
            {
                Console.SetCursorPosition(berry.berryX, berry.berryY);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("■");
            }
        }

    }
}
