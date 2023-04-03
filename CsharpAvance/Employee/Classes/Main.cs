using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employee.Classes
{
    internal static class Main
    {

        public static void Start()
        {
            List<(int num, string msg)> mainMenu = new() {
                (1, "Ajouter un employé"),
                (2, "Afficher le salaire des employés"),
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
                MainHelpers.ShowMenu(mainMenu);
                int choice = MainHelpers.AskMenuChoice(mainMenu);
                Console.Clear();
                Salarie salarie;
                switch (choice)
                {
                    case 1:
                        MainHelpers.ShowMenu(salarieMenu);
                        int choiceSalarie = MainHelpers.AskMenuChoice(salarieMenu);
                        switch (choiceSalarie)
                        {
                            case 1:
                                salaries.Add(MainHelpers.AskUserSalarie());
                                break;
                            case 2:
                                salaries.Add(MainHelpers.AskUserCommercial());
                                break;
                            case 0:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        if (MainHelpers.isSalariesEmpty(salaries))
                        {
                            Console.WriteLine("La liste des salariés est vide");
                            break;
                        }
                        foreach (Salarie s in salaries)
                        {
                            Console.WriteLine("------------------");
                            Console.WriteLine(s.GetSalaireString());
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 3:
                        if (MainHelpers.isSalariesEmpty(salaries))
                        {
                            Console.WriteLine("La liste des salariés est vide");
                            break;
                        }
                        salarie = MainHelpers.askUserSalarieByName(salaries);
                        Console.WriteLine(salarie.GetSalaireString());
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
