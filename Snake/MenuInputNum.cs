using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuInputNum : MenuItem
    {
        public int Value { get; set; }
        private int min;
        private int max;
        private int step;

        public MenuInputNum(string name, int value, int min, int max, int step) : base(name)
        {
            this.Value = value;
            this.step = step;
            this.min = min;
            this.max = max;
        }

        public void bigger()
        {
            Value += Convert.ToInt32(Value != max) * step;
        }

        public void smaller()
        {
            Value -= Convert.ToInt32(Value != min) * step;
        }

        public override void Show()
        {
            string s = name, s1 = string.Format("{0} {1} {2}", Config.MENU_SYMBOL_BACK, Value, Config.MENU_SYMBOL_FORWARD);
            for (int i = name.Length; i < Config.MENU_ITEM_LENGTH - s1.Length; i++)
            {
                s += " ";
            }
            Console.Write(s);
            if (Value == min)
            {
                Console.ForegroundColor = Config.COLOR_DISABLED;
                Console.Write("{0}", Config.MENU_SYMBOL_BACK);
                Console.ForegroundColor = Config.COLOR_DEFAULT;
                Console.Write(" {0} {1}", Value, Config.MENU_SYMBOL_FORWARD);
            }
            else if (Value == max)
            {
                Console.Write("{0} {1} ", Config.MENU_SYMBOL_BACK, Value);
                Console.ForegroundColor = Config.COLOR_DISABLED;
                Console.Write("{0}", Config.MENU_SYMBOL_FORWARD);
                Console.ForegroundColor = Config.COLOR_DEFAULT;
            }
            else
            {
                Console.WriteLine(s1);
            }
        }
    }
}
