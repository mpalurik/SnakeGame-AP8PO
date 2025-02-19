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

            Berry berry = new Berry();

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


        private void DisplayGameOver()
        {
            Console.SetCursorPosition(WindowWidth / 5, WindowHeight / 2);
            Console.WriteLine($"Game Over! Score: {score}");
        }

        

        static void Main()
        {
            SnakeGame game = new SnakeGame();
            game.Run();
        }
    }
}
