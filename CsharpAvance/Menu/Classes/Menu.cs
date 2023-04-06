using Menu.Struct;
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
                else if (!menu.Any(item => item.num == choice))
                {
                    Console.WriteLine("Rentrez une valeur présent dans le menu");
                    isCorrect = false;
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

        public static void HandleIHM(List<(int num, string msg, Action action)> menu, string menuTitle = "--- Menu ---", bool isLooping = true)
        {
            List<(int num, string msg)> menuSimplified = new();
            menu.ForEach(item => menuSimplified.Add((item.num, item.msg)));
            do
            {
                Menu.ShowMenu(menuSimplified, menuTitle);
                int choice = Menu.AskMenuChoice(menuSimplified);
                Console.Clear();
                var menuChoice = menu.FirstOrDefault(m => m.num == choice);
                if (menuChoice == default((int, string, Action)))
                {
                    throw new Exception("Choice not in the menu");
                }
                else if (menuChoice.action == null)
                {
                    return;
                }
                else
                {
                    menuChoice.action();
                }
            } while (isLooping);
        }
    }
}
