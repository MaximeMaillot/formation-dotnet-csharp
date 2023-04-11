using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Helper.Classes
{
    internal static class AskUserHelper
    {
        public static bool ParseUserString(string data, out string result)
        {
            if (data == null || data.Length == 0)
            {
                result = null;
                return false;
            }
            result = data;
            return true;
        }
    }
}