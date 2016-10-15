using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Frame : Figure
    {
        public Frame(int width, int height)
        {
            height-=2;
            for (int x = 0; x < width; x++)
            {
                pList.Add(new Point(x, 1, Config.SYMBOL_BORDER));
                pList.Add(new Point(x, height, Config.SYMBOL_BORDER));
            }
            width-=1;
            for (int y = 1; y < height; y++)
            {
                pList.Add(new Point(0, y, Config.SYMBOL_BORDER));
                pList.Add(new Point(width, y, Config.SYMBOL_BORDER));
            }
        }
        public List<Point> getPList()
        {
            return pList;
        }

        public void Draw()
        {
            base.Draw(Config.COLOR_BORDER);
        }
    }
}
