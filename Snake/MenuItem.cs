using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuItem
    {
        public string name { get; set; }
        private DelegateMenuItem action;
        public MenuItemType type { get; set; }

        public MenuItem(string name = "Undefined", MenuItemType type = MenuItemType.BUTTON, DelegateMenuItem action = null)
        {
            this.name = name;
            this.type = type;
            this.action = action;
        }

        public void act(List<MenuItem> list = null)
        {
            action(list);
        }
    }
}
