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
        public void GenerateFood()
        {
            x = rand.Next(1, Config.WINDOW_WIDTH - 3);
            y = rand.Next(1, Config.WINDOW_HEIGHT - 5);
            symbol = Config.SYMBOL_FOOD;
        }
    }
}
