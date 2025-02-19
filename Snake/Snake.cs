using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    class Snake
    {
        public Pixel head;
        public List<int> bodyXPositions;
        public List<int> bodyYPositions;
        private MovementDirection movementDirection { get; set; }

        public Snake(Pixel head, MovementDirection movementDirection)
        {
            this.head = head;
            bodyXPositions = new List<int>();
            bodyYPositions = new List<int>();
            this.movementDirection = movementDirection;
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
    }
}
