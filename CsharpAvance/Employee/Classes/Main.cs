using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Classes
{
    internal static class Main
    {
        public static void Start()
        {
            List<(int num, string msg)> mainMenu = new() {
                (1, "Ajouter un employé"),
                (2, "Afficher le salaire de l'employé"),
                (3, "Rechercher un employé"),
                (0, "Quitter")
            };
            List<(int num, string msg)> salarieMenu = new() {
                (1, "Salarié"),
                (2, "Commercial"),
                (0, "Retour")
            };
            List<Salarie> salaries = new();
            do
            {
                ShowMenu(mainMenu);
                int choice = AskMenuChoice(mainMenu);
                switch (choice)
                {
                    case 1:
                        ShowMenu(salarieMenu);
                        int choiceSalarie = AskMenuChoice(salarieMenu);
                        switch (choiceSalarie)
                        {
                            case 1:
                                AskUserSalarie();
                                break;
                            case 2:
                                break;
                            case 0:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void ShowMenu(List<(int num, string msg)> menu, string menuTitle = "--- Menu ---")
        {
            Console.WriteLine(menuTitle);
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.num}. {item.msg}");
            }
        }

        private static int AskMenuChoice(List<(int num, string msg)> menu)
        {
            int choice;
            bool isCorrect;
            do
            {
                Console.Write("Votre choix : ");
                isCorrect = int.TryParse(Console.ReadLine(), out choice);
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

        private static string AskUserName()
        {
            Console.Write("Merci de saisir le nom : ");
            return Console.ReadLine();
        }

        private static int AskUserSalaire()
        {
            bool isCorrect;
            int salaire;
            do
            {
                Console.Write("Merci de saisir le salaire : ");
                isCorrect = int.TryParse(Console.ReadLine(), out salaire);
                if (isCorrect && salaire <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Un salaire ne peut pas être négatif");
                }
            } while (!isCorrect);
            return salaire;
        }

        private static string AskUserMatricule()
        {
            Console.Write("Merci de saisir le matricule : ");
            return Console.ReadLine();
        }

        private static string AskUserCategorie()
        {
            Console.Write("Merci de saisir la catégorie : ");
            return Console.ReadLine();
        }

        private static string AskUserService()
        {
            Console.Write("Merci de saisir le service : ");
            return Console.ReadLine();
        }

        private static Salarie AskUserSalarie()
        {
            return new Salarie(AskUserName(), AskUserSalaire(), AskUserMatricule(), AskUserCategorie(), AskUserService());
        }

        private static int AskUserChiffreAffaires()
        {
            bool isCorrect;
            int chiffreAffaires;
            do
            {
                Console.Write("Merci de saisir le chiffre d'affaires : ");
                isCorrect = int.TryParse(Console.ReadLine(), out chiffreAffaires);
                if (isCorrect && chiffreAffaires <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Un chiffre d'affaires ne peut pas être négatif");
                }
            } while (!isCorrect);
            return chiffreAffaires;
        }

        private static int AskUserComission()
        {
            bool isCorrect;
            int comission;
            do
            {
                Console.Write("Merci de saisir la comission : ");
                isCorrect = int.TryParse(Console.ReadLine(), out comission);
                if (isCorrect && comission <= 0)
                {
                    isCorrect = false;
                    Console.WriteLine("Une comission ne peut pas être négatif");
                }
            } while (!isCorrect);
            return comission;
        }


        private static Commercial AskUserCommercial()
        {
            return new Commercial(AskUserSalarie(), AskUserChiffreAffaires(), AskUserComission());
        }
    }
}
