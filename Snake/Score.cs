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
        public int max_result;

        public Score(int result = 0)
        {
            this.result = result;
            max_result = Config.MAX_RESULT;
        }

        public void Inc()
        {
            if (result == max_result)
            {
                max_result++;
            }
            result++;
        }

        public void Show()
        {
            Console.ForegroundColor = Config.COLOR_DEFAULT;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("SCORE: {0}", result);
            Console.SetCursorPosition(11, 0);
            Console.WriteLine("MAX: {0}", max_result);
        }

        public static void ShowPause()
        {
            string s = "PRESS ANY KEY TO CONTINUE";
            Console.SetCursorPosition(2 * Config.FIELD_WIDTH - s.Length - 1, 0);
            Console.Write(s);
        }

        public static void HidePause()
        {
            string s = "                         ";
            Console.SetCursorPosition(2 * Config.FIELD_WIDTH - s.Length - 1, 0);
            Console.Write(s);
        }

    }
}
