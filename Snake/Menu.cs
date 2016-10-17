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
                Console.SetCursorPosition(5 - Convert.ToInt32(item.GetType() == typeof(MenuItem)), 3 + position);
                item.Show();
                if (index == -1 && item.GetType() != typeof(MenuItem))
                {
                    index = position;
                }
                position++;
            }
            return index;
        }

        public void Show()
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
                Console.WriteLine(Config.MENU_SYMBOL_SELECTED);
                Console.SetCursorPosition(Config.MENU_ITEM_LENGTH + 4, 3 + position);
                Console.CursorVisible = (list[position].GetType() == typeof(MenuInputChar));
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
                            if (list[position] is MenuInputNum)
                            {
                                (list[position] as MenuInputNum).smaller();
                                Console.SetCursorPosition(5, 3 + position);
                                list[position].Show();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (list[position] is MenuInputNum)
                            {
                                (list[position] as MenuInputNum).bigger();
                                Console.SetCursorPosition(5, 3 + position);
                                list[position].Show();
                            }
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            if (list[position] is MenuButton)
                            {
                                (list[position] as MenuButton).act();
                            }
                            flag = false;
                            break;
                        default:
                            if (list[position] is MenuInputChar)
                            {
                                (list[position] as MenuInputChar).Value = key.KeyChar;
                                Console.SetCursorPosition(5, 3 + position);
                                list[position].Show();
                            }
                            break;
                    }
                } while (list[position].GetType() == typeof(MenuItem));
            }
        }
    }
}
