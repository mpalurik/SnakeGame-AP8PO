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
        public List<Pixel> body;
        public InputHandler inputHandler;
        public ConsoleColor color;
        public int score { get; set; }
        public MovementDirection movementDirection { get; set; }

        public Snake(Pixel head, MovementDirection movementDirection, InputHandler inputHandler, ConsoleColor color)
        {
            this.head = head;
            body = new List<Pixel>();
            this.movementDirection = movementDirection;
            this.inputHandler = inputHandler;
            this.color = color;
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

            body.Add(new Pixel(prevX, prevY));

            if ( body.Count > score )
            {
                body.RemoveAt(0);
            }
        }
    }
}
