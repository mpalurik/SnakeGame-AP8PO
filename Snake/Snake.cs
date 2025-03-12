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
        public InputHandler inputHandler;
        public int score { get; set; }
        public MovementDirection movementDirection { get; set; }

        public Snake(Pixel head, MovementDirection movementDirection, InputHandler inputHandler)
        {
            this.head = head;
            bodyXPositions = new List<int>();
            bodyYPositions = new List<int>();
            this.movementDirection = movementDirection;
            this.inputHandler = inputHandler;
        }

        public void MoveSnake()
        {
            int prevX = head.X;
            int prevY = head.Y;

            switch (movementDirection)
            {
                case MovementDirection.UP:
                    head.Y--;
                    break;
                case MovementDirection.DOWN:
                    head.Y++;
                    break;
                case MovementDirection.LEFT:
                    head.X--;
                    break;
                case MovementDirection.RIGHT:
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
