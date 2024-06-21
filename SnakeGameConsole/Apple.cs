using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameConsole
{
    public class Apple
    {
        public Apple(Field field) 
        {
            Random random = new Random();
            posX = random.Next(1, field.Width-1);
            posY = random.Next(1, field.Height-1);
        }
        private int posX;
        private int posY;
        public int PosX { get { return posX; } set { posX = value; } }
        public int PosY { get { return posY; } set { posY = value; } }
    }
}
