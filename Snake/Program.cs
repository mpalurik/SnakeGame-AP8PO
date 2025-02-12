using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;
            Random random = new Random();
            int score = 5;
            int gameOver = 0;

            Pixel head = new Pixel
            {
                XPosition = screenWidth / 2,
                YPosition = screenHeight / 2,
                Color = ConsoleColor.Red
            };

            string movementDirection = "RIGHT";
            List<int> bodyXPositions = new List<int>();
            List<int> bodyYPositions = new List<int>();

            int berryX = random.Next(0, screenWidth);
            int berryY = random.Next(0, screenHeight);

            DateTime currentTime = DateTime.Now;
            DateTime nextTime = DateTime.Now;
            string buttonPressed = "no";

            while (true)
            {
                Console.Clear();

                // Check for collision with walls
                if (head.XPosition == screenWidth - 1 || head.XPosition == 0 || head.YPosition == screenHeight - 1 || head.YPosition == 0)
                {
                    gameOver = 1;
                }

                // Draw borders
                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                    Console.SetCursorPosition(i, screenHeight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                    Console.SetCursorPosition(screenWidth - 1, i);
                    Console.Write("■");
                }

                // Check if snake eats the berry
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryX == head.XPosition && berryY == head.YPosition)
                {
                    score++;
                    berryX = random.Next(1, screenWidth - 2);
                    berryY = random.Next(1, screenHeight - 2);
                }

                // Draw snake body
                for (int i = 0; i < bodyXPositions.Count; i++)
                {
                    Console.SetCursorPosition(bodyXPositions[i], bodyYPositions[i]);
                    Console.Write("■");

                    // Check for collision with body
                    if (bodyXPositions[i] == head.XPosition && bodyYPositions[i] == head.YPosition)
                    {
                        gameOver = 1;
                    }
                }

                if (gameOver == 1)
                {
                    break;
                }

                // Draw snake head
                Console.SetCursorPosition(head.XPosition, head.YPosition);
                Console.ForegroundColor = head.Color;
                Console.Write("■");

                // Draw berry
                Console.SetCursorPosition(berryX, berryY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");

                currentTime = DateTime.Now;
                buttonPressed = "no";

                // Handle user input
                while (true)
                {
                    nextTime = DateTime.Now;
                    if (nextTime.Subtract(currentTime).TotalMilliseconds > 500) { break; }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key.Equals(ConsoleKey.UpArrow) && movementDirection != "DOWN" && buttonPressed == "no")
                        {
                            movementDirection = "UP";
                            buttonPressed = "yes";
                        }
                        if (key.Key.Equals(ConsoleKey.DownArrow) && movementDirection != "UP" && buttonPressed == "no")
                        {
                            movementDirection = "DOWN";
                            buttonPressed = "yes";
                        }
                        if (key.Key.Equals(ConsoleKey.LeftArrow) && movementDirection != "RIGHT" && buttonPressed == "no")
                        {
                            movementDirection = "LEFT";
                            buttonPressed = "yes";
                        }
                        if (key.Key.Equals(ConsoleKey.RightArrow) && movementDirection != "LEFT" && buttonPressed == "no")
                        {
                            movementDirection = "RIGHT";
                            buttonPressed = "yes";
                        }
                    }
                }

                // Update snake body positions
                bodyXPositions.Add(head.XPosition);
                bodyYPositions.Add(head.YPosition);

                // Move snake head
                switch (movementDirection)
                {
                    case "UP":
                        head.YPosition--;
                        break;
                    case "DOWN":
                        head.YPosition++;
                        break;
                    case "LEFT":
                        head.XPosition--;
                        break;
                    case "RIGHT":
                        head.XPosition++;
                        break;
                }

                // Remove tail if snake is not growing
                if (bodyXPositions.Count > score)
                {
                    bodyXPositions.RemoveAt(0);
                    bodyYPositions.RemoveAt(0);
                }
            }

            // Game over screen
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }

        class Pixel
        {
            public int XPosition { get; set; }
            public int YPosition { get; set; }
            public ConsoleColor Color { get; set; }
        }
    }
}