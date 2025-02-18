using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class SnakeGame
    {
        private const int WindowHeight = 16;
        private const int WindowWidth = 32;
        private const int InitialScore = 5;
        private const int GameSpeed = 100;

        private Pixel head;
        private List<int> bodyXPositions;
        private List<int> bodyYPositions;
        private int berryX, berryY;
        private int score;
        private string movementDirection;
        private Random random;
        private bool isGameOver;

        public SnakeGame()
        {
            Console.WindowHeight = WindowHeight;
            Console.WindowWidth = WindowWidth;

            random = new Random();
            score = InitialScore;
            movementDirection = "RIGHT";
            isGameOver = false;

            head = new Pixel { X = WindowWidth / 2, Y = WindowHeight / 2, Color = ConsoleColor.Red };
            bodyXPositions = new List<int>();
            bodyYPositions = new List<int>();

            SpawnBerry();
        }

        public void Run()
        {
            while (!isGameOver)
            {
                Console.Clear();
                DrawBorders();
                CheckCollisions();
                DrawBerry();
                DrawSnake();
                HandleInput();
                MoveSnake();
                Thread.Sleep(GameSpeed);
            }
            DisplayGameOver();
        }

        private void DrawBorders()
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

        private void CheckCollisions()
        {
            if (head.X == 0 || head.X == WindowWidth - 1 || head.Y == 0 || head.Y == WindowHeight - 1)
            {
                isGameOver = true;
            }
            for (int i = 0; i < bodyXPositions.Count; i++)
            {
                if (bodyXPositions[i] == head.X && bodyYPositions[i] == head.Y)
                {
                    isGameOver = true;
                    return;
                }
            }
            if (head.X == berryX && head.Y == berryY)
            {
                score++;
                SpawnBerry();
            }
        }

        private void DrawBerry()
        {
            Console.SetCursorPosition(berryX, berryY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }

        private void DrawSnake()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < bodyXPositions.Count; i++)
            {
                Console.SetCursorPosition(bodyXPositions[i], bodyYPositions[i]);
                Console.Write("■");
            }
            Console.SetCursorPosition(head.X, head.Y);
            Console.ForegroundColor = head.Color;
            Console.Write("■");
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
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

        private void MoveSnake()
        {
            int prevX = head.X;
            int prevY = head.Y;

            switch (movementDirection)
            {
                case "UP":
                    head.Y--;
                    break;
                case "DOWN":
                    head.Y++;
                    break;
                case "LEFT":
                    head.X--;
                    break;
                case "RIGHT":
                    head.X++;
                    break;
            }

            bodyXPositions.Add(prevX);
            bodyYPositions.Add(prevY);

            if (bodyXPositions.Count > score)
            {
                bodyXPositions.RemoveAt(0);
                bodyYPositions.RemoveAt(0);
            }
        }

        private void SpawnBerry()
        {
            berryX = random.Next(1, WindowWidth - 2);
            berryY = random.Next(1, WindowHeight - 2);
        }

        private void DisplayGameOver()
        {
            Console.SetCursorPosition(WindowWidth / 5, WindowHeight / 2);
            Console.WriteLine($"Game Over! Score: {score}");
        }

        class Pixel
        {
            public int X { get; set; }
            public int Y { get; set; }
            public ConsoleColor Color { get; set; }
        }

        static void Main()
        {
            SnakeGame game = new SnakeGame();
            game.Run();
        }
    }
}
