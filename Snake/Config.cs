using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Config
    {
        /* CONSTANTS */

        private const string CONFIG_PATH = @"..\..\config.data";

        public const ConsoleColor COLOR_BORDER = ConsoleColor.White;
        public const ConsoleColor COLOR_DEFAULT = ConsoleColor.White;
        public const ConsoleColor COLOR_SNAKE = ConsoleColor.Green;
        public const ConsoleColor COLOR_FOOD = ConsoleColor.Yellow;

        public const Direction SNAKE_START_DIRECTION = Direction.RIGHT;
        public const int SNAKE_START_LENGTH = 3;

        public const int WINDOW_HEIGHT_MAX = 30;
        public const int WINDOW_HEIGHT_MIN = 15;
        public const int WINDOW_WIDTH_MAX = 45;
        public const int WINDOW_WIDTH_MIN = 23;

        public const int REFRESH_SPEED_MAX = 1000;
        public const int REFRESH_SPEED_MIN = 50;

        public const char SYMBOL_MENU_ARROW = '»';

        /* FIELDS */

        public static int WINDOW_HEIGHT = 21; /* RECOMMENDED MIN - 15 */
        public static int WINDOW_WIDTH = 35; /* RECOMMENDED MIN - 23 */

        public static char SYMBOL_BORDER = '+';
        public static char SYMBOL_EMPTY = ' ';
        public static char SYMBOL_SNAKE = '@';
        public static char SYMBOL_FOOD = 'o';

        public static int REFRESH_SPEED = 150;
        public static int MAX_RESULT = 0;

        public static int SNAKE_START_POSITION_X;
        public static int SNAKE_START_POSITION_Y;

        private static string[] data = new string[8];

        private enum DataType { WINDOW_WIDTH, WINDOW_HEIGHT, SYMBOL_BORDER, SYMBOL_EMPTY, SYMBOL_SNAKE, SYMBOL_FOOD, REFRESH_SPEED, MAX_RESULT };
     

        public Config()
        {
            try { data = System.IO.File.ReadAllLines(CONFIG_PATH); } catch { }
            try { WINDOW_WIDTH = Int32.Parse(data[(int)DataType.WINDOW_WIDTH]); } catch { }
            try { WINDOW_HEIGHT = Int32.Parse(data[(int)DataType.WINDOW_HEIGHT]); } catch { }
            try { SYMBOL_BORDER = Char.Parse(data[(int)DataType.SYMBOL_BORDER]); } catch { }
            try { SYMBOL_EMPTY = Char.Parse(data[(int)DataType.SYMBOL_EMPTY]); } catch { }
            try { SYMBOL_SNAKE = Char.Parse(data[(int)DataType.SYMBOL_SNAKE]); } catch { }
            try { SYMBOL_FOOD = Char.Parse(data[(int)DataType.SYMBOL_FOOD]); } catch { }
            try { REFRESH_SPEED = Int32.Parse(data[(int)DataType.REFRESH_SPEED]); } catch { }
            try { MAX_RESULT = Int32.Parse(data[(int)DataType.MAX_RESULT]); } catch { }
            SNAKE_START_POSITION_X = WINDOW_WIDTH / 4 - 2;
            SNAKE_START_POSITION_Y = WINDOW_HEIGHT / 2 - 1;
        }

        public static void LoadModifiedData()
        {
            data[(int)DataType.WINDOW_WIDTH] = WINDOW_WIDTH + "";
            data[(int)DataType.WINDOW_HEIGHT] = WINDOW_HEIGHT + "";
            data[(int)DataType.SYMBOL_BORDER] = SYMBOL_BORDER + "";
            data[(int)DataType.SYMBOL_EMPTY] = SYMBOL_EMPTY + "";
            data[(int)DataType.SYMBOL_SNAKE] = SYMBOL_SNAKE + "";
            data[(int)DataType.SYMBOL_FOOD] = SYMBOL_FOOD + "";
            data[(int)DataType.REFRESH_SPEED] = REFRESH_SPEED + "";
            data[(int)DataType.MAX_RESULT] = MAX_RESULT + "";
            try { System.IO.File.WriteAllLines(CONFIG_PATH, data); } catch { };
        }

        public static void Cancel(List<MenuItem> list = null)
        {
            Program.Main();
        }

        public static void SaveSettings(List<MenuItem> list = null)
        {
            foreach(MenuItem item in list)
            {
                switch (item.type)
                {
                    case MenuItemType.CHAR:
                        switch((item as MenuItemChar).field)
                        {
                            case MenuItemChar.MenuItemCharField.SNAKE:
                                Config.SYMBOL_SNAKE = (item as MenuItemChar).value;
                                break;
                            case MenuItemChar.MenuItemCharField.FOOD:
                                Config.SYMBOL_FOOD = (item as MenuItemChar).value;
                                break;
                            case MenuItemChar.MenuItemCharField.BORDER:
                                Config.SYMBOL_BORDER = (item as MenuItemChar).value;
                                break;
                        }
                        break;
                    case MenuItemType.COUNTER:
                        switch ((item as MenuItemSize).field)
                        {
                            case MenuItemSize.MenuItemSizeField.WIDTH:
                                Config.WINDOW_WIDTH = (item as MenuItemSize).value;
                                break;
                            case MenuItemSize.MenuItemSizeField.HEIGHT:
                                Config.WINDOW_HEIGHT = (item as MenuItemSize).value;
                                break;
                        }
                        break;
                }
            }
            Config.LoadModifiedData();
            Config.Cancel();
        }
    }
}
