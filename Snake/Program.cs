using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private static void NewGame()
        {
            Console.Clear();

            Score score = new Score();
            score.Show();

            Frame frame = new Frame(Config.FIELD_WIDTH, Config.FIELD_HEIGHT);
            frame.Draw();

            Point position = new Point(Config.SNAKE_START_POSITION_X, Config.SNAKE_START_POSITION_Y, Config.SYMBOL_SNAKE);
            Snake snake = new Snake(position, Config.SNAKE_START_LENGTH, Config.SNAKE_START_DIRECTION);
            snake.Draw();

            Food food = new Food();
            food.GenerateFood(snake);
            food.Draw();

            while (true)
            {
                if (snake.hannibal() || snake.bump(frame))
                {
                    Console.SetCursorPosition(0, Config.FIELD_HEIGHT - 1);
                    GameOver(score.result);
                    break;
                }

                if (snake.eat(food))
                {
                    food.GenerateFood(snake);
                    food.Draw();
                    score.Inc();
                    score.Show();
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (snake.HandleKey(key.Key))
                    {
                        Score.ShowPause();
                        key = Console.ReadKey(true);
                        snake.HandleKey(key.Key);
                        Score.HidePause();
                    }
                }
                Thread.Sleep(Config.REFRESH_SPEED);
            }
        }
        private static void Settings()
        {
            List<MenuItem> settingList = new List<MenuItem>();
            settingList.Add(new MenuItem("Characters"));
            MenuItem SnakeChar = new MenuInputChar("Snake", Config.SYMBOL_SNAKE);
            MenuItem FoodChar = new MenuInputChar("Food", Config.SYMBOL_FOOD);
            MenuItem BorderChar = new MenuInputChar("Border", Config.SYMBOL_BORDER);
            settingList.Add(SnakeChar);
            settingList.Add(FoodChar);
            settingList.Add(BorderChar);
            settingList.Add(new MenuItem(""));
            settingList.Add(new MenuItem("Field sizes"));
            MenuItem FieldWidth = new MenuInputNum("Width", Config.FIELD_WIDTH, Config.FIELD_WIDTH_MIN, Config.FIELD_WIDTH_MAX, 1);
            MenuItem FieldHeight = new MenuInputNum("Height", Config.FIELD_HEIGHT, Config.FIELD_HEIGHT_MIN, Config.FIELD_HEIGHT_MAX, 1);
            settingList.Add(FieldWidth);
            settingList.Add(FieldHeight);
            settingList.Add(new MenuItem(""));
            settingList.Add(new MenuItem("Snake speed"));
            MenuItem SnakeSpeed = new MenuInputNum("Sec. per step", Config.REFRESH_SPEED, Config.REFRESH_SPEED_MIN, Config.REFRESH_SPEED_MAX, Config.REFRESH_SPEED_STEP);
            settingList.Add(SnakeSpeed);
            settingList.Add(new MenuItem(""));
            settingList.Add(new MenuItem(""));
            settingList.Add(new MenuButton("Save changes", delegate {
                Config.SYMBOL_SNAKE = (SnakeChar as MenuInputChar).Value;
                Config.SYMBOL_FOOD = (FoodChar as MenuInputChar).Value;
                Config.SYMBOL_BORDER = (BorderChar as MenuInputChar).Value;
                Config.FIELD_HEIGHT = (FieldHeight as MenuInputNum).Value;
                Config.FIELD_WIDTH = (FieldWidth as MenuInputNum).Value;
                Config.REFRESH_SPEED = (SnakeSpeed as MenuInputNum).Value;
                Config.LoadModifiedData();
                Menu();
            }));
            settingList.Add(new MenuButton("Cancel", new DelegateMenuItem(Menu)));
            Menu settings = new Menu("SETTINGS", settingList);
            settings.Show();
        }
        private static void Menu()
        {
            List<MenuItem> menuList = new List<MenuItem>();
            menuList.Add(new MenuButton("New game", new DelegateMenuItem(NewGame)));
            menuList.Add(new MenuButton("Settings", new DelegateMenuItem(Settings)));
            menuList.Add(new MenuItem(""));
            menuList.Add(new MenuButton("Exit", new DelegateMenuItem(Exit)));
            Menu menu = new Menu("CONSOLE SNAKE", menuList);
            menu.Show();
        }
        private static void Exit()
        {
            Environment.Exit(0);
        }
        private static void GameOver(int result)
        {
            string s = "";
            for (int i = 0; i < Config.FIELD_WIDTH - 1; i++)
            {
                s += Config.SYMBOL_BORDER + " ";
            }
            for (int i = 1; i < Config.FIELD_HEIGHT - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(s);
            }
            List<string> message = new List<string>();
            message.Add(" ------------------------------------- ");
            message.Add(" |                                   | ");
            message.Add(" |             GAME OVER             | ");
            message.Add(" |                                   | ");
            message.Add(" |     -  -  -  -  -  -  -  -  -     | ");
            message.Add(" |                                   | ");
            message.Add(" |     -  -  -  -  -  -  -  -  -     | ");
            message.Add(" |                                   | ");
            message.Add(" |  Do you want to try again? (Y/N)  | ");
            message.Add(" |                                   | ");
            message.Add(" ------------------------------------- ");
            string finalScore = string.Format("{0} {1} POINT{2}", (result > Config.MAX_RESULT ? "NEW RECORD!" : "YOU HAVE GOT"), result, (result == 1 ? "" : "S"));
            if (result > Config.MAX_RESULT)
            {
                Config.MAX_RESULT = result;
                Config.LoadModifiedData();
            }
            for (int i = 0; i < message.Count(); i++)
            {
                Console.SetCursorPosition((2 * Config.FIELD_WIDTH - message[i].Length) / 2, (Config.FIELD_HEIGHT - message.Count()) / 2 + i);
                Console.Write(message[i]);
            }
            Console.SetCursorPosition((2 * Config.FIELD_WIDTH - finalScore.Length) / 2, Config.FIELD_HEIGHT / 2 - (Config.FIELD_HEIGHT % 2 == 1 ? 0 : 1));
            Console.Write(finalScore);
            Console.SetCursorPosition(0, Config.FIELD_HEIGHT - 1);
            bool flag = true;
            while (flag)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.SetCursorPosition(0, Config.FIELD_HEIGHT - 1);
                Console.Write(" ");
                switch (key)
                {
                    case ConsoleKey.Y:
                        NewGame();
                        break;
                    case ConsoleKey.N:
                        Main();
                        flag = false;
                        break;
                }
            }
        }

        public static void Main()
        {
            Console.ForegroundColor = Config.COLOR_DEFAULT;
            Console.CursorVisible = false;
            Config data = new Config();
            Menu();
        }
    }
}
