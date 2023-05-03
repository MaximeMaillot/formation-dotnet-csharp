using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Classes
{
    public static class ConsoleHelper
    {
        public static string ReadLine()
        {
            string res = Console.ReadLine() ?? "";
            return res.Trim();
        }

        public static void WriteLineInColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
