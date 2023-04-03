using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Classes
{
    public static class Menu
    {
        public static int AskMenuChoice(List<(int num, string msg)> menu)
        {
            int choice;
            bool isCorrect;
            do
            {
                Console.Write("Votre choix : ");
                isCorrect = int.TryParse(Console.ReadLine().Trim(), out choice);
                if (!isCorrect)
                {
                    Console.WriteLine("Rentrez une valeur numérique");
                }
                if (!menu.Any(item => item.num == choice))
                {
                    Console.WriteLine("Rentrez une valeur présent dans le menu");
                }
            } while (!isCorrect);
            return choice;
        }

        public static void ShowMenu(List<(int num, string msg)> menu, string menuTitle = "--- Menu ---")
        {
            Console.WriteLine(menuTitle);
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.num}. {item.msg}");
            }
        }
    }
}
