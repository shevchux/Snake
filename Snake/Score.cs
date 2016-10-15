using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Score
    {
        public int result;

        public Score(int result = 0)
        {
            this.result = result;
        }

        public void Inc()
        {
            result++;
        }

        public void Show()
        {
            Console.ForegroundColor = Config.COLOR_DEFAULT;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("SCORE: {0}", result);
        }

    }
}
