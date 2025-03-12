using System;
using System.Collections.Generic;

namespace Snake
{
    class GameState
    {
        public List<Snake> Snakes { get; set; }
        public List<Berry> Berries { get; set; }
        public bool isGameOver;

        public GameState()
        {
            Snakes = new List<Snake>();
            Berries = new List<Berry>();
            isGameOver = false;
        }
    }
}
