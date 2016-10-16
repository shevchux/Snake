using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menu
    {
        string title;
        List<MenuItem> list;

        public Menu(string title, List<MenuItem> list)
        {
            this.title = title;
            this.list = list;
        }

        private int ShowMenuItems()
        {
            int position = 0, index = -1;
            foreach (MenuItem item in list)
            {
                Console.SetCursorPosition(5, 3 + position);
                switch (item.type)
                {
                    case MenuItemType.TITLE:
                        Console.SetCursorPosition(4, 3 + position);
                        Console.ForegroundColor = Config.COLOR_FOOD;
                        Console.WriteLine(item.name);
                        Console.ForegroundColor = Config.COLOR_DEFAULT;
                        break;
                    case MenuItemType.CHAR:
                        Console.WriteLine(item.name);
                        Console.SetCursorPosition(20, 3 + position);
                        Console.WriteLine("{0}", (item as MenuItemChar).value);
                        break;
                    case MenuItemType.COUNTER:
                        Console.WriteLine(item.name);
                        string s = "   < " + (item as MenuItemSize).value + " >";
                        Console.SetCursorPosition(21 - s.Length, 3 + position);
                        Console.WriteLine("{0}", s);
                        break;
                    case MenuItemType.BUTTON:
                        Console.WriteLine(item.name);
                        break;
                }
                position++;
                Console.ForegroundColor = Config.COLOR_DEFAULT;
                if (index == -1 && item.type != MenuItemType.TITLE)
                {
                    index = position - 1;
                }
            }
            return index;
        }

        public void Open()
        {
            Console.Clear();
            Console.ForegroundColor = Config.COLOR_SNAKE;
            Console.SetCursorPosition(4, 1);
            Console.WriteLine("{0}", title);
            Console.ForegroundColor = Config.COLOR_DEFAULT;
            
            int position = ShowMenuItems();
            bool flag = position != -1;

            while (flag)
            {
                Console.SetCursorPosition(3, 3 + position);
                Console.WriteLine(Config.SYMBOL_MENU_ARROW);
                Console.SetCursorPosition(20, 3 + position);
                Console.CursorVisible = (list[position].type == MenuItemType.CHAR);
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.CursorVisible = false;
                do
                {
                    Console.SetCursorPosition(3, 3 + position);
                    Console.WriteLine(Config.SYMBOL_EMPTY);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            position = (position == 0 ? list.Count : position) - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            position = (position == list.Count - 1 ? 0 : position + 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (list[position].type == MenuItemType.COUNTER)
                            {
                                switch ((list[position] as MenuItemSize).field)
                                {
                                    case MenuItemSize.MenuItemSizeField.WIDTH:
                                        if ((list[position] as MenuItemSize).value > Config.WINDOW_WIDTH_MIN)
                                        {
                                            (list[position] as MenuItemSize).value -= 1;
                                        }
                                        break;
                                    case MenuItemSize.MenuItemSizeField.HEIGHT:
                                        if ((list[position] as MenuItemSize).value > Config.WINDOW_HEIGHT_MIN)
                                        {
                                            (list[position] as MenuItemSize).value -= 1;
                                        }
                                        break;
                                }
                                string s = "   < " + (list[position] as MenuItemSize).value + " >";
                                Console.SetCursorPosition(21 - s.Length, 3 + position);
                                Console.WriteLine("{0}", s);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (list[position].type == MenuItemType.COUNTER)
                            {
                                switch ((list[position] as MenuItemSize).field)
                                {
                                    case MenuItemSize.MenuItemSizeField.WIDTH:
                                        if ((list[position] as MenuItemSize).value < Config.WINDOW_WIDTH_MAX)
                                        {
                                            (list[position] as MenuItemSize).value += 1;
                                        }
                                        break;
                                    case MenuItemSize.MenuItemSizeField.HEIGHT:
                                        if ((list[position] as MenuItemSize).value < Config.WINDOW_HEIGHT_MAX)
                                        {
                                            (list[position] as MenuItemSize).value += 1;
                                        }
                                        break;
                                }
                                string s = "   < " + (list[position] as MenuItemSize).value + " >";
                                Console.SetCursorPosition(21 - s.Length, 3 + position);
                                Console.WriteLine("{0}", s);
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (list[position].type == MenuItemType.BUTTON)
                            {
                                Console.Clear();
                                list[position].act(list);
                                flag = false;
                            }
                            break;
                        default:
                            if (list[position].type == MenuItemType.CHAR)
                            {
                                (list[position] as MenuItemChar).value = key.KeyChar;
                                Console.SetCursorPosition(20, 3 + position);
                                Console.WriteLine("{0}", key.KeyChar);
                            }
                            break;
                    }
                } while (list[position].type == MenuItemType.TITLE);
            }
        }
    }
}
