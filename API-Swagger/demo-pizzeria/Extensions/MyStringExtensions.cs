using System.Runtime.CompilerServices;

namespace demo_pizzeria.Extensions
{
    public static class MyStringExtensions
    {
        public static string Capitalize(this string message)
        {
            return message[0].ToString().ToUpper() + message.Substring(1);
        }
    }
}
