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
            head.Draw(Config.COLOR_SNAKE);
        }

        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public List<Point> getPList()
        {
            return pList;
        }

        public bool bump(Frame frame)
        {
            Point head = pList.Last();
            List<Point> frameList = frame.getPList();
            for (int i = 0; i < frameList.Count(); i++)
            {
                if (frameList[i].x == head.x && frameList[i].y == head.y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            base.Draw(Config.COLOR_SNAKE);
        }

        public bool hannibal()
        {
            Point head = pList.Last();
            for (int i = 0; i < pList.Count() - 2; i++)
            {
                if (head.x == pList[i].x && head.y == pList[i].y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool eat(Food food)
        {
            Point head = GetNextPoint();
            if (head.x == food.x && head.y == food.y)
            {
                head.Draw(Config.COLOR_SNAKE);
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
