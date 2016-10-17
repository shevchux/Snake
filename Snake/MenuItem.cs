using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuItem
    {
        protected string name;

        public MenuItem(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            Console.ForegroundColor = Config.COLOR_FOOD;
            Console.Write(name);
            Console.ForegroundColor = Config.COLOR_DEFAULT;
        }
    }
}
