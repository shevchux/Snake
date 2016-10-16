using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Config
    {
        private const string CONFIG_PATH = @"..\..\config.data";

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

        public const ConsoleColor COLOR_BORDER = ConsoleColor.White;
        public const ConsoleColor COLOR_DEFAULT = ConsoleColor.White;
        public const ConsoleColor COLOR_SNAKE = ConsoleColor.Green;
        public const ConsoleColor COLOR_FOOD = ConsoleColor.Yellow;

        public const Direction SNAKE_START_DIRECTION = Direction.RIGHT;
        public const int SNAKE_START_LENGTH = 3;

        public Config()
        {
            try { data = System.IO.File.ReadAllLines(Config.CONFIG_PATH); } catch { }
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
            data[(int)DataType.WINDOW_WIDTH] = String.Format("{0}", WINDOW_WIDTH);
            data[(int)DataType.WINDOW_HEIGHT] = String.Format("{0}", WINDOW_HEIGHT);
            data[(int)DataType.SYMBOL_BORDER] = String.Format("{0}", SYMBOL_BORDER);
            data[(int)DataType.SYMBOL_EMPTY] = String.Format("{0}", SYMBOL_EMPTY);
            data[(int)DataType.SYMBOL_SNAKE] = String.Format("{0}", SYMBOL_SNAKE);
            data[(int)DataType.SYMBOL_FOOD] = String.Format("{0}", SYMBOL_FOOD);
            data[(int)DataType.REFRESH_SPEED] = String.Format("{0}", REFRESH_SPEED);
            data[(int)DataType.MAX_RESULT] = String.Format("{0}", MAX_RESULT);
            try { System.IO.File.WriteAllLines(CONFIG_PATH, data); } catch { };
        }
    }
}
