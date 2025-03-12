using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class InputHandler
    {
        Dictionary<ConsoleKey, MovementDirection> keyMap;

        public InputHandler(int keyMapIndex)
        {
            keyMap = GameSettings.keyMap[keyMapIndex];
        }

        private bool IsOppositeDirection(MovementDirection currentDirection, MovementDirection newDirection)
        {
            return (currentDirection == MovementDirection.UP && newDirection == MovementDirection.DOWN) ||
                   (currentDirection == MovementDirection.DOWN && newDirection == MovementDirection.UP) ||
                   (currentDirection == MovementDirection.LEFT && newDirection == MovementDirection.RIGHT) ||
                   (currentDirection == MovementDirection.RIGHT && newDirection == MovementDirection.LEFT);
        }

        public MovementDirection HandleInput(MovementDirection currentDirection)
        {
            if (!Console.KeyAvailable)
            {
                return currentDirection;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            if (keyMap.TryGetValue(key, out MovementDirection newDirection))
            {
                if (!IsOppositeDirection(currentDirection, newDirection))
                {
                    return newDirection;
                }
            }

            return currentDirection;
        }
    }
}
