using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Config
    {
        public const short WINDOW_HEIGHT = 25;
        public const short WINDOW_WIDTH = 40;

        public const char SYMBOL_BORDER = '+';
        public const char SYMBOL_EMPTY = ' ';
        public const char SYMBOL_SNAKE = '*';
        public const char SYMBOL_FOOD = 'o';

        public const ConsoleColor COLOR_BORDER = ConsoleColor.White;
        public const ConsoleColor COLOR_DEFAULT = ConsoleColor.White;
        public const ConsoleColor COLOR_SNAKE = ConsoleColor.Green;
        public const ConsoleColor COLOR_FOOD = ConsoleColor.Yellow;

        public const Direction SNAKE_START_DIRECTION = Direction.RIGHT;
        public const int SNAKE_START_LENGTH = 3;
        public const int SNAKE_START_POSITION_X = WINDOW_WIDTH / 4 - 2;
        public const int SNAKE_START_POSITION_Y = WINDOW_HEIGHT / 2 - 1;

        public const int REFRESH_SPEED = 100;
    }
}
