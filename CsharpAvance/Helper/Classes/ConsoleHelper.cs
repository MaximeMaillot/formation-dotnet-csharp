namespace Helper.Classes
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Write a message in the console with a certain color
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public static void WriteLineInColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static string ReadLine()
        {
            return (Console.ReadLine() ?? "").Trim();
        }
    }
}
