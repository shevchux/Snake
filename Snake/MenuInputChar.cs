using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuInputChar : MenuItem
    {
        public char Value { get; set; }

        public MenuInputChar(string name, char value) : base(name)
        {
            this.Value = value;
        }
        



        public override void Show()
        {
            string s = name;
            for (int i = name.Length; i < Config.MENU_ITEM_LENGTH - 1; i++)
            {
                s += " ";
            }
            s += Value;
            Console.Write(s);
        }
    }
}
