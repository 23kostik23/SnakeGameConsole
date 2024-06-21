using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SnakeGameConsole
{
    public class Field
    {
        public Field(int width,  int height)
        {
            this.height = height;
            this.width = width;
        }

        private int height;
        private int width;
        private Snake snake;
        private Apple apple;

        public int Height { get { return height; } set { height = value; } }
        public int Width {  get { return width; } set {  width = value; } }

        public void Draw(Field field, Snake snake, Apple apple)
        {
            this.snake = snake;
            this.apple = apple;
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine($"Snake: {this.snake.PosX}, {this.snake.PosY}\nApple: {this.apple.PosX}, {this.apple.PosY}");
            Console.WriteLine($"Score: {snake.Length}");
            for(int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (i == 0 || j == 0 || i == field.Height - 1 || j == field.Width - 1)
                    {
                        Console.Write("#");
                    }
                    else if (apple.PosX == j && apple.PosY == i)
                    {
                        Console.Write("A");
                    }
                    else if (i == snake.PosY && j == snake.PosX)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        bool isTailSegment = false;
                        foreach (int[] XY in snake.Tail)
                        {
                            int tailX = XY[0];
                            int tailY = XY[1];
                            if (i == tailY && j == tailX)
                            {
                                Console.Write("o");
                                isTailSegment = true;
                                break;
                            }
                        }
                        if (!isTailSegment)
                        {
                            Console.Write(" ");
                        }
                    }
                    if (snake.PosX == 0 && snake.CurrentDirection == Direction.Left)
                    {
                        snake.PosX = field.Width - 1;
                    }
                    else if (snake.PosX == field.Width - 1 && snake.CurrentDirection == Direction.Right)
                    {
                        snake.PosX = 1;
                    }
                    else if (snake.PosY == 0 && snake.CurrentDirection == Direction.Up)
                    {
                        snake.PosY = field.Height - 1;
                    }
                    else if (snake.PosY == field.Height - 1 && snake.CurrentDirection == Direction.Down)
                    {
                        snake.PosY = 1;
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void HandleInput(ConsoleKeyInfo x)
        {
            if (x.Key == ConsoleKey.W && snake.CurrentDirection != Direction.Down)
            {
                snake.CurrentDirection = Direction.Up;
            }
            else if (x.Key == ConsoleKey.A && snake.CurrentDirection != Direction.Right)
            {
                snake.CurrentDirection = Direction.Left;
            }
            else if (x.Key == ConsoleKey.S && snake.CurrentDirection != Direction.Up)
            {
                snake.CurrentDirection = Direction.Down;
            }
            else if (x.Key == ConsoleKey.D && snake.CurrentDirection != Direction.Left)
            {
                snake.CurrentDirection = Direction.Right;
            }
        }


        public Apple AppleEaten()
        {
            this.apple = new Apple(this);
             return this.apple;
        }
    }
}
