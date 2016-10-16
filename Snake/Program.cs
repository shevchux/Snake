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
        private static void NewGame(List<MenuItem> list = null)
        {
            Console.Clear();

            Score score = new Score();
            score.Show();

            Frame frame = new Frame(Config.WINDOW_WIDTH, Config.WINDOW_HEIGHT);
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
                    Console.SetCursorPosition(0, Config.WINDOW_HEIGHT - 1);
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
        private static void Settings(List<MenuItem> list = null)
        {
            List<MenuItem> settingList = new List<MenuItem>();
            settingList.Add(new MenuItem("Characters", MenuItemType.TITLE));
            settingList.Add(new MenuItemChar("Snake", Config.SYMBOL_SNAKE, MenuItemChar.MenuItemCharField.SNAKE));
            settingList.Add(new MenuItemChar("Food", Config.SYMBOL_FOOD, MenuItemChar.MenuItemCharField.FOOD));
            settingList.Add(new MenuItemChar("Border", Config.SYMBOL_BORDER, MenuItemChar.MenuItemCharField.BORDER));
            settingList.Add(new MenuItem("", MenuItemType.TITLE));
            settingList.Add(new MenuItem("Field sizes", MenuItemType.TITLE));
            settingList.Add(new MenuItemSize("Width", Config.WINDOW_WIDTH, MenuItemSize.MenuItemSizeField.WIDTH));
            settingList.Add(new MenuItemSize("Height", Config.WINDOW_HEIGHT, MenuItemSize.MenuItemSizeField.HEIGHT));
            settingList.Add(new MenuItem("", MenuItemType.TITLE));
            settingList.Add(new MenuItem("Save changes", MenuItemType.BUTTON, new DelegateMenuItem(Config.SaveSettings)));
            settingList.Add(new MenuItem("Cancel", MenuItemType.BUTTON, new DelegateMenuItem(Config.Cancel)));
            Menu settings = new Menu("SETTINGS", settingList);
            settings.Open();
        }
        private static void Exit(List<MenuItem> list = null)
        {
            Environment.Exit(0);
        }
        private static void GameOver(int result)
        {
            string s = "";
            for (int i = 0; i < 2 * Config.WINDOW_WIDTH - 1; i++)
            {
                s += Config.SYMBOL_BORDER;
            }
            for (int i = 1; i < Config.WINDOW_HEIGHT - 1; i++)
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
                Console.SetCursorPosition((2 * Config.WINDOW_WIDTH - message[i].Length) / 2, (Config.WINDOW_HEIGHT - message.Count()) / 2 + i);
                Console.Write(message[i]);
            }
            Console.SetCursorPosition((2 * Config.WINDOW_WIDTH - finalScore.Length) / 2, Config.WINDOW_HEIGHT / 2 - (Config.WINDOW_HEIGHT % 2 == 1 ? 0 : 1));
            Console.Write(finalScore);
            Console.SetCursorPosition(0, Config.WINDOW_HEIGHT - 1);
            bool flag = true;
            while (flag)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.SetCursorPosition(0, Config.WINDOW_HEIGHT - 1);
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
            Console.CursorVisible = false;
            Config data = new Config();

            List<MenuItem> menuList = new List<MenuItem>();
            menuList.Add(new MenuItem("New game", MenuItemType.BUTTON, new DelegateMenuItem(NewGame)));
            menuList.Add(new MenuItem("Settings", MenuItemType.BUTTON, new DelegateMenuItem(Settings)));
            menuList.Add(new MenuItem("", MenuItemType.TITLE));
            menuList.Add(new MenuItem("Exit", MenuItemType.BUTTON, new DelegateMenuItem(Exit)));
            Menu menu = new Menu("CONSOLE SNAKE", menuList);
            menu.Open();
        }
    }
}
