using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace Helper.Classes
{
    public static class AskUserHelper
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

        public static int AskUserInt(string msg, string error = "Rentrez un entier valide")
        {
            int result;
            bool isCorrect;
            do
            {
                Console.Write(msg);
                isCorrect = int.TryParse(ConsoleHelper.ReadLine(), out result);
                if (!isCorrect || result < 0)
                {
                    ConsoleHelper.WriteLineInColor(error, ConsoleColor.Red);
                }
            } while (!isCorrect);
            return result;
        }

        public static DateTime? AskUserNullableDateTime(string msg, string error = "Rentrez une date correct")
        {
            do
            {
                Console.Write(msg);
                if (!ParseUserString(ConsoleHelper.ReadLine(), out string ask))
                {
                    return null;
                }
                if (DateTime.TryParse(ask, out DateTime date))
                {
                    return date;
                }
                else
                {
                    ConsoleHelper.WriteLineInColor(error, ConsoleColor.Red);
                }
            } while (true);
        }

        public static string AskUserString(string msg, string error = "Rentrez une chaîne de caractères valide")
        {
            string result;
            bool isCorrect;
            do
            {
                Console.Write(msg);
                isCorrect = ParseUserString(ConsoleHelper.ReadLine(), out result);
                if (!isCorrect)
                {
                    ConsoleHelper.WriteLineInColor(error, ConsoleColor.Red);
                }
            } while (!isCorrect);
            return result;
        }

        public static string AskUserPhone(string msg, string error = "Un numéro de téléphone est composé de 10 chiffres")
        {
            bool isCorrect;
            string phone;
            do
            {
                Console.Write(msg);
                phone = ConsoleHelper.ReadLine();
                isCorrect = int.TryParse(phone, out _) && phone.Length == 10;
                if (!isCorrect)
                {
                    ConsoleHelper.WriteLineInColor(error, ConsoleColor.Red);
                }
            } while (!isCorrect);
            return phone;
        }

        public static decimal AskUserDecimal(string msg, string error = "Rentrez un décimal")
        {
            bool isCorrect;
            decimal result;
            do
            {
                Console.Write(msg);
                isCorrect = decimal.TryParse(Console.ReadLine(), out result);
                if (!isCorrect)
                {
                    ConsoleHelper.WriteLineInColor(error, ConsoleColor.Red);
                }
            } while (!isCorrect);
            return result;
        }
    }
}