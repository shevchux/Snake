using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            Console.SetBufferSize(Config.WINDOW_WIDTH, Config.WINDOW_HEIGHT);
            Console.CursorVisible = false;

            Point LU = new Point(0, 0);
            Point RD = new Point(Config.WINDOW_WIDTH - 2, Config.WINDOW_HEIGHT - 4);
            Frame frame = new Frame(LU, RD, Config.SYMBOL_BORDER);
            frame.Draw();

            Point position = new Point(Config.SNAKE_START_POSITION_X, Config.SNAKE_START_POSITION_Y, Config.SYMBOL_SNAKE);
            Snake snake = new Snake(position, Config.SNAKE_START_LENGTH, Config.SNAKE_START_DIRECTION);
            snake.Draw();

            Food food = new Food();
            food.GenerateFood();
            food.Draw();

            while (true)
            {
                if (snake.eat(food))
                {
                    food.GenerateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(Config.REFRESH_SPEED);
            }
        }
    }
}
