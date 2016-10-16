using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : Point
    {
        Random rand = new Random();
        public void GenerateFood(Snake snake)
        {
            do
            {
                x = rand.Next(1, Config.WINDOW_WIDTH - 3);
                y = rand.Next(2, Config.WINDOW_HEIGHT - 5);
            }
            while (matchWithBody(snake));
            symbol = Config.SYMBOL_FOOD;
        }

        public bool matchWithBody(Snake snake)
        {
            List<Point> snakeList = snake.getPList();
            foreach(Point item in snakeList)
            {
                if (item.x == x && item.y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            base.Draw(Config.COLOR_FOOD);
        }
    }
}
