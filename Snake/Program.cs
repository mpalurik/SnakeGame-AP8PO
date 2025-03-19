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
        GameState gameState = new();
        RenderHandler renderHandler = new();
        CollisionHandler collisionHandler = new();

        public SnakeGame()
        {
            List<ConsoleColor> colors = new() { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Yellow };

            for (int i = 0; i < GameSettings.playerCount; i++)
            {
                var inputHandler = new InputHandler(i);
                gameState.Snakes.Add(new Snake(new Pixel((GameSettings.windowWidth / 2), (GameSettings.windowHeight / 2 + i)), MovementDirection.RIGHT, inputHandler, colors[i]));
                gameState.Berries.Add(new Berry(gameState));
            }
        }

        public void Run()
        {

            while (!gameState.isGameOver)
            {
                Console.Clear();
                renderHandler.RenderBorders();
                var collision = collisionHandler.CheckCollisions(gameState);

                renderHandler.RenderBerries(gameState.Berries);
                renderHandler.RenderSnakes(gameState.Snakes);

                foreach (var snake in gameState.Snakes)
                {
                    snake.movementDirection = snake.inputHandler.HandleInput(snake.movementDirection);
                    snake.MoveSnake();
                }

                Thread.Sleep(GameSettings.gameSpeed);
            }
            DisplayGameOver();
        }

        private void DisplayGameOver()
        {
            Console.SetCursorPosition(GameSettings.windowWidth / 5, GameSettings.windowHeight / 2);
            Console.WriteLine($"Game Over! Score: {gameState.Snakes[0].score}");
        }

    }
}