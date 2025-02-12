using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Program
    {
        private static int screenWidth = 32;
        private static int screenHeight = 16;
        private static Random random = new Random();
        private static int score = 5;
        private static bool isGameOver = false;

        private static Pixel head = new Pixel
        {
            XPosition = screenWidth / 2,
            YPosition = screenHeight / 2,
            Color = ConsoleColor.Red
        };

        private static string movementDirection = "RIGHT";
        private static List<int> bodyXPositions = new List<int>();
        private static List<int> bodyYPositions = new List<int>();

        private static int berryX;
        private static int berryY;

        static void Main(string[] args)
        {
            InitializeGame();
            RunGameLoop();
            ShowGameOverScreen();
        }

        private static void InitializeGame()
        {
            Console.WindowHeight = screenHeight;
            Console.WindowWidth = screenWidth;
            SpawnBerry();
        }

        private static void RunGameLoop()
        {
            while (!isGameOver)
            {
                Console.Clear();
                CheckCollisions();
                DrawBorders();
                HandleBerryConsumption();
                DrawSnake();
                DrawBerry();
                HandleInput();
                UpdateSnakePosition();
                Thread.Sleep(500); // Control game speed
            }
        }

        private static void CheckCollisions()
        {
            // Check collision with walls
            if (head.XPosition == screenWidth - 1 || head.XPosition == 0 || head.YPosition == screenHeight - 1 || head.YPosition == 0)
            {
                isGameOver = true;
            }

            // Check collision with body
            for (int i = 0; i < bodyXPositions.Count; i++)
            {
                if (bodyXPositions[i] == head.XPosition && bodyYPositions[i] == head.YPosition)
                {
                    isGameOver = true;
                    break;
                }
            }
        }

        private static void DrawBorders()
        {
            Console.ForegroundColor = ConsoleColor.White;
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
        }

        private static void HandleBerryConsumption()
        {
            if (berryX == head.XPosition && berryY == head.YPosition)
            {
                score++;
                SpawnBerry();
            }
        }

        private static void DrawSnake()
        {
            // Draw snake body
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < bodyXPositions.Count; i++)
            {
                Console.SetCursorPosition(bodyXPositions[i], bodyYPositions[i]);
                Console.Write("■");
            }

            // Draw snake head
            Console.SetCursorPosition(head.XPosition, head.YPosition);
            Console.ForegroundColor = head.Color;
            Console.Write("■");
        }

        private static void DrawBerry()
        {
            Console.SetCursorPosition(berryX, berryY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }

        private static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow when movementDirection != "DOWN":
                        movementDirection = "UP";
                        break;
                    case ConsoleKey.DownArrow when movementDirection != "UP":
                        movementDirection = "DOWN";
                        break;
                    case ConsoleKey.LeftArrow when movementDirection != "RIGHT":
                        movementDirection = "LEFT";
                        break;
                    case ConsoleKey.RightArrow when movementDirection != "LEFT":
                        movementDirection = "RIGHT";
                        break;
                }
            }
        }

        private static void UpdateSnakePosition()
        {
            // Add current head position to body
            bodyXPositions.Add(head.XPosition);
            bodyYPositions.Add(head.YPosition);

            // Move head based on direction
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

        private static void SpawnBerry()
        {
            berryX = random.Next(1, screenWidth - 2);
            berryY = random.Next(1, screenHeight - 2);
        }

        private static void ShowGameOverScreen()
        {
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }
    }

    class Pixel
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public ConsoleColor Color { get; set; }
    }
}