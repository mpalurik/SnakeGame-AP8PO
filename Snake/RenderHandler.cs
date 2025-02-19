using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class RenderHandler
    {
        public void RenderBorders(int WindowHeight,int WindowWidth)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, WindowHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(WindowWidth - 1, i);
                Console.Write("■");
            }
        }

        public void RenderSnake(Snake snake)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < snake.bodyXPositions.Count; i++)
            {
                Console.SetCursorPosition(snake.bodyXPositions[i], snake.bodyYPositions[i]);
                Console.Write("■");
            }
            Console.SetCursorPosition(snake.head.X, snake.head.Y);
            Console.ForegroundColor = snake.head.Color;
            Console.Write("■");
        }

        public void RenderBerry(Berry berry)
        {
            Console.SetCursorPosition(berry.berryX, berry.berryY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }

    }
}
