using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    class CollisionHandler
    {
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
    }
}
