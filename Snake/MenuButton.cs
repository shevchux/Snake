using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuButton : MenuItem
    {
        private DelegateMenuItem action;

        public MenuButton(string name, DelegateMenuItem action) : base(name)
        {
            this.action = action;
        }

        public void act()
        {
            if (action != null)
            {
                action();
            }
        }

        public override void Show()
        {
            Console.Write(name);
        }
    }
}
