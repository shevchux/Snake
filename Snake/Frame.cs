using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Frame : Figure
    {
        public Frame(Point p1, Point p2, char border)
        {
            for (int x = p1.x; x <= p2.x; x++)
            {
                pList.Add(new Point(x, p1.y, border));
                pList.Add(new Point(x, p2.y, border));
            }
            for (int y = p1.y + 1; y < p2.y; y++)
            {
                pList.Add(new Point(p1.x, y, border));
                pList.Add(new Point(p2.x, y, border));
            }
        }
    }
}
