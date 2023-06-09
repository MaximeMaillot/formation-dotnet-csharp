﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes.Helper
{
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Write a message in the console with a certain color
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public static void WriteInColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
