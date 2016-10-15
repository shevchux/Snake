using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Config
    {
        public static short WINDOW_HEIGHT = 25;
        public static short WINDOW_WIDTH = 80;

        public static char SYMBOL_BORDER = '+';
        public static char SYMBOL_EMPTY = ' ';
        public static char SYMBOL_SNAKE = '*';
        public static char SYMBOL_FOOD = 'o';

        public static Direction SNAKE_START_DIRECTION = Direction.RIGHT;
        public static int SNAKE_START_LENGTH = 3;
        public static int SNAKE_START_POSITION_X = WINDOW_WIDTH / 4 - 2;
        public static int SNAKE_START_POSITION_Y = WINDOW_HEIGHT / 2 - 1;

        public static int REFRESH_SPEED = 100;
    }
}
