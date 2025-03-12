using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameSettings
    {
        public static List<Dictionary<ConsoleKey, MovementDirection>> keyMap = new()
        { new Dictionary<ConsoleKey, MovementDirection>
            {
                { ConsoleKey.UpArrow, MovementDirection.UP },
                { ConsoleKey.DownArrow, MovementDirection.DOWN },
                { ConsoleKey.LeftArrow, MovementDirection.LEFT },
                { ConsoleKey.RightArrow, MovementDirection.RIGHT }
            },
            new Dictionary<ConsoleKey, MovementDirection>
            {
                { ConsoleKey.W, MovementDirection.UP },
                { ConsoleKey.S, MovementDirection.DOWN },
                { ConsoleKey.A, MovementDirection.LEFT },
                { ConsoleKey.D, MovementDirection.RIGHT }
            },
            new Dictionary<ConsoleKey, MovementDirection>
            {
                { ConsoleKey.I, MovementDirection.UP },
                { ConsoleKey.K, MovementDirection.DOWN },
                { ConsoleKey.L, MovementDirection.LEFT },
                { ConsoleKey.J, MovementDirection.RIGHT }
            },
        };

        public static int windowHeight = 16;
        public static int windowWidth = 32;
        public static int initialScore = 0;
        public static int gameSpeed = 100;
        public static int playerCount = 1;
    }
}
