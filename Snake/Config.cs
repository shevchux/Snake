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
        public const ConsoleColor COLOR_DISABLED = ConsoleColor.Gray;

        public const Direction SNAKE_START_DIRECTION = Direction.RIGHT;
        public const int SNAKE_START_LENGTH = 3;

        public const int FIELD_HEIGHT_MAX = 30;
        public const int FIELD_HEIGHT_MIN = 15;
        public const int FIELD_WIDTH_MAX = 45;
        public const int FIELD_WIDTH_MIN = 23;

        public const int REFRESH_SPEED_MAX = 300;
        public const int REFRESH_SPEED_MIN = 25;
        public const int REFRESH_SPEED_STEP = 5;

        public const char MENU_SYMBOL_SELECTED = '»';
        public const char MENU_SYMBOL_BACK = '<';
        public const char MENU_SYMBOL_FORWARD = '>';
        public const int MENU_ITEM_LENGTH = 24;

        /* FIELDS */

        public static int FIELD_HEIGHT = 22; /* RECOMMENDED MIN - 15 */
        public static int FIELD_WIDTH = 28; /* RECOMMENDED MIN - 23 */

        public static char SYMBOL_BORDER = '+';
        public static char SYMBOL_EMPTY = ' ';
        public static char SYMBOL_SNAKE = '@';
        public static char SYMBOL_FOOD = 'o';

        public static int REFRESH_SPEED = 150;
        public static int MAX_RESULT = 0;

        public static int SNAKE_START_POSITION_X;
        public static int SNAKE_START_POSITION_Y;

        private static string[] data = new string[8];

        public enum DataType { WINDOW_WIDTH, WINDOW_HEIGHT, SYMBOL_BORDER, SYMBOL_EMPTY, SYMBOL_SNAKE, SYMBOL_FOOD, REFRESH_SPEED, MAX_RESULT };

        public Config()
        {
            try { data = System.IO.File.ReadAllLines(CONFIG_PATH); } catch { }
            try { FIELD_WIDTH = Int32.Parse(data[(int)DataType.WINDOW_WIDTH]); } catch { }
            try { FIELD_HEIGHT = Int32.Parse(data[(int)DataType.WINDOW_HEIGHT]); } catch { }
            try { SYMBOL_BORDER = Char.Parse(data[(int)DataType.SYMBOL_BORDER]); } catch { }
            try { SYMBOL_EMPTY = Char.Parse(data[(int)DataType.SYMBOL_EMPTY]); } catch { }
            try { SYMBOL_SNAKE = Char.Parse(data[(int)DataType.SYMBOL_SNAKE]); } catch { }
            try { SYMBOL_FOOD = Char.Parse(data[(int)DataType.SYMBOL_FOOD]); } catch { }
            try { REFRESH_SPEED = Int32.Parse(data[(int)DataType.REFRESH_SPEED]); } catch { }
            try { MAX_RESULT = Int32.Parse(data[(int)DataType.MAX_RESULT]); } catch { }
            SNAKE_START_POSITION_X = FIELD_WIDTH / 4 - 2;
            SNAKE_START_POSITION_Y = FIELD_HEIGHT / 2 - 1;
        }

        public static void LoadModifiedData()
        {
            data[(int)DataType.WINDOW_WIDTH] = FIELD_WIDTH + "";
            data[(int)DataType.WINDOW_HEIGHT] = FIELD_HEIGHT + "";
            data[(int)DataType.SYMBOL_BORDER] = SYMBOL_BORDER + "";
            data[(int)DataType.SYMBOL_EMPTY] = SYMBOL_EMPTY + "";
            data[(int)DataType.SYMBOL_SNAKE] = SYMBOL_SNAKE + "";
            data[(int)DataType.SYMBOL_FOOD] = SYMBOL_FOOD + "";
            data[(int)DataType.REFRESH_SPEED] = REFRESH_SPEED + "";
            data[(int)DataType.MAX_RESULT] = MAX_RESULT + "";
            try { System.IO.File.WriteAllLines(CONFIG_PATH, data); } catch { };
        }
    }
}
