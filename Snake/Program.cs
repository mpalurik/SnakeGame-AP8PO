using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame game = new SnakeGame();
            game.Run();
        }
    }

    class SnakeGame
    {
        private const int WindowHeight = 16;
        private const int WindowWidth = 32;
        private const int InitialScore = 5;
        private const int GameSpeed = 100;

<<<<<<< HEAD
=======
        private Pixel head;
        private List<Pixel> body;
        private Pixel berry;
>>>>>>> fcdb841d4089c5711138021b992278564588fdba
        private int score;
        private bool isGameOver;

        InputHandler inputHandler = new InputHandler();
        RenderHandler renderHandler = new RenderHandler();
        CollisionHandler collisionHandler = new CollisionHandler();
        Snake snake;


        public SnakeGame()
        {
            Console.WindowHeight = WindowHeight;
            Console.WindowWidth = WindowWidth;

            score = InitialScore;
            isGameOver = false;
            // SpawnBerry();

<<<<<<< HEAD
            Berry berry = new Berry();
=======
            head = new Pixel { X = WindowWidth / 2, Y = WindowHeight / 2, Color = ConsoleColor.Red };
            body = new List<Pixel>();
>>>>>>> fcdb841d4089c5711138021b992278564588fdba

            Snake snake = new Snake(new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.Red), MovementDirection.RIGHT);
        }

        public void Run()
        {

            while (!isGameOver)
            {
                Console.Clear();
                renderHandler.RenderBorders(WindowHeight, WindowWidth);
                collisionHandler.CheckCollisions();// score game is over a switch //mozna return berry a predat dal
                renderHandler.RenderBerry(berry);
                renderHandler.RenderSnake(snake);
                inputHandler.HandleInput(snake.movementDirection);

                MoveSnake();
                Thread.Sleep(GameSpeed);
            }
            DisplayGameOver();
        }

<<<<<<< HEAD
=======
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
            foreach (var pixel in body)
            {
                if (pixel.X == head.X && pixel.Y == head.Y)
                {
                    isGameOver = true;
                    return;
                }
            }
            if (head.X == berry.X && head.Y == berry.Y)
            {
                score++;
                SpawnBerry();
            }
        }

        private void DrawBerry()
        {
            Console.SetCursorPosition(berry.X, berry.Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }

        private void DrawSnake()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var pixel in body)
            {
                Console.SetCursorPosition(pixel.X, pixel.Y);
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

            body.Add(new Pixel { X = prevX, Y = prevY, Color = ConsoleColor.Green });

            if (body.Count > score)
            {
                body.RemoveAt(0);
            }
        }

        private void SpawnBerry()
        {
            berry = new Pixel { X = random.Next(1, WindowWidth - 2), Y = random.Next(1, WindowHeight - 2), Color = ConsoleColor.Cyan };
        }
>>>>>>> fcdb841d4089c5711138021b992278564588fdba

        private void DisplayGameOver()
        {
            Console.SetCursorPosition(WindowWidth / 5, WindowHeight / 2);
            Console.WriteLine($"Game Over! Score: {score}");
        }
<<<<<<< HEAD

        

        static void Main()
        {
            SnakeGame game = new SnakeGame();
            game.Run();
        }
=======
>>>>>>> fcdb841d4089c5711138021b992278564588fdba
    }

    class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
    }
}