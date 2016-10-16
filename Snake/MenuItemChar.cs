using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuItemChar : MenuItem
    {
        public enum MenuItemCharField { SNAKE, FOOD, BORDER };
        public char value { get; set; }
        public MenuItemCharField field;
        public MenuItemChar(string name = "Undefined", char value = '0', MenuItemCharField field = MenuItemCharField.BORDER) : base(name, MenuItemType.CHAR, null)
        {
            this.value = value;
            this.field = field;
        }
    }
}
