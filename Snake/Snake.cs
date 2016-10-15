using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            for(int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = pList[0];
            pList.Remove(tail);
            tail.Clear();

            Point head = GetNextPoint();
            pList.Add(head);
            head.Draw();
        }

        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public bool eat(Food food)
        {
            Point head = GetNextPoint();
            if (head.x == food.x && head.y == food.y)
            {
                /*food.symbol = Config.SYMBOL_SNAKE;
                Point p = new Point();
                p.x = food.x;
                p.y = food.y;
                p.symbol = Config.SYMBOL_SNAKE;
                pList.Add(p);*/
                head.Draw();
                pList.Add(new Point(head));

                return true;
            }
            else
            {
                return false;
            }
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.UP || direction == Direction.DOWN)
                    {
                        direction = Direction.LEFT;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction == Direction.UP || direction == Direction.DOWN)
                    {
                        direction = Direction.RIGHT;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (direction == Direction.LEFT || direction == Direction.RIGHT)
                    {
                        direction = Direction.UP;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction == Direction.LEFT || direction == Direction.RIGHT)
                    {
                        direction = Direction.DOWN;
                    }
                    break;
                default:
                    break;
            }
        }
        
    }
}
