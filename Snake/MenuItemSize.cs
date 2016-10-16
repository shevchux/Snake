using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class MenuItemSize : MenuItem
    {
        public enum MenuItemSizeField { WIDTH, HEIGHT }

        public int value { get; set; }
        public MenuItemSizeField field { get; set; }
        public MenuItemSize(string name = "Undefined", int value = 0, MenuItemSizeField field = MenuItemSizeField.WIDTH) : base(name, MenuItemType.COUNTER, null)
        {
            this.value = value;
            this.field = field;
        }
    }
}
