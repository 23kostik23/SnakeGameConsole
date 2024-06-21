using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SnakeGameConsole.Program;

namespace SnakeGameConsole
{
    public class Snake
    {
        public Snake(Field field) {
            this.field = field;
            posX = field.Width / 2;
            posY = field.Height / 2;
            Tail = new List<int[]>();
        }
        private int posX;
        private int posY;
        private int length = 1;
        private Field field;
        private Direction direction = Direction.None;

        public int PosX { get { return posX; } set { posX = value; } }
        public int PosY { get { return posY; } set { posY = value; } }
        public int Length { get { return length; } set { length = value; } }
        public Direction CurrentDirection { get { return direction; } set { direction = value; } }
        public List<int[]> Tail;

        public void Move()
        {
            if (Tail.Count > 0)
            {
                Tail.Insert(0, new int[] { posX, posY });
                if (Tail.Count > Length - 1)
                {
                    Tail.RemoveAt(Tail.Count - 1);
                }
            }

            if (direction == Direction.Up) 
            {
                posY--;
            }
            else if (direction == Direction.Down) 
            {
                posY++;
            }
            else if (direction == Direction.Left)
            {
                posX--;
            }
            else if (direction == Direction.Right)
            {
                posX++;
            }

            if (posX == 0 && direction == Direction.Left)
            {
                posX = field.Width - 2;
            }
            else if (posX == field.Width - 1 && direction == Direction.Right)
            {
                posX = 1;
            }
            else if (posY == 0 && direction == Direction.Up)
            {
                posY = field.Height - 2;
            }
            else if (posY == field.Height - 1 && direction == Direction.Down)
            {
                posY = 1;
            }
        }
    }
}
