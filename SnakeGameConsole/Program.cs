using System.IO.Pipes;

namespace SnakeGameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Field field = new Field(21, 21);
            Snake snake = new Snake(field);
            Apple apple = new Apple(field);

            int score = 0;
            bool gameOver = false;
            while (!gameOver)
            {
                if (snake.PosX == apple.PosX && snake.PosY == apple.PosY)
                {
                    snake.Tail.Add([apple.PosX, apple.PosY]);
                    apple = field.AppleEaten();
                    snake.Length++;
                }
                snake.Move();
                var TailCheck = snake.Tail;
                foreach(var item in TailCheck)
                {
                    if (snake.PosX == item[0] && snake.PosY == item[1])
                    {
                        gameOver = true;
                        break;
                    }
                }
                field.Draw(field, snake, apple);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    field.HandleInput(keyInfo);
                }
            }
            Console.Clear();
            Console.WriteLine("Game over!\n\n");
            bool answer = false;
            while(!answer)
            {
                Console.WriteLine("Do you want to play again? [Y/N]");
                ConsoleKeyInfo answ = Console.ReadKey();
                if (answ.Key == ConsoleKey.Y)
                {
                    field = new Field(11, 11);
                    snake = new Snake(field);
                    apple = new Apple(field);
                    gameOver = false;
                    while (!gameOver)
                    {
                        if (snake.PosX == apple.PosX && snake.PosY == apple.PosY)
                        {
                            snake.Tail.Add([apple.PosX, apple.PosY]);
                            apple = field.AppleEaten();
                            snake.Length++;
                        }
                        snake.Move();
                        var TailCheck = snake.Tail;
                        foreach (var item in TailCheck)
                        {
                            if (snake.PosX == item[0] && snake.PosY == item[1])
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        field.Draw(field, snake, apple);
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            field.HandleInput(keyInfo);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Game over!\n\n");
                }
                else if (answ.Key == ConsoleKey.N) break;
                else continue;
            }
        }
    }
}
