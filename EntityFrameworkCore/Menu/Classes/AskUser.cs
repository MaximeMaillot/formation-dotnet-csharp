using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Classes
{
    public static class AskUser
    {
        public static string AskUserString(string msg)
        {
            Console.Write(msg);
            return ConsoleHelper.ReadLine();
        }

        public static int AskUserInt(string msg)
        {
            bool isCorrect;
            int result;
            do
            {
                Console.Write(msg);
                isCorrect = int.TryParse(Console.ReadLine(), out result);
            } while (!isCorrect);
            return result;
        }
    }
}
