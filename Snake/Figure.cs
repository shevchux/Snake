using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList = new List<Point>();

        public virtual void Draw(ConsoleColor color = Config.COLOR_DEFAULT)
        {
            foreach (Point p in pList)
            {
                p.Draw(color);
            }
            Console.ForegroundColor = Config.COLOR_DEFAULT;
        }
    }
}
