using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPile.Classes
{
    internal class IHM
    {
        public static void Start()
        {
            PileArray<Personne> personnes = new();
            PileArray<string> names = new();
            PileArray<decimal> numbers = new();
            List<(int num, string msg)> mainMenu = new() {
                (1, "Afficher une Pile"),
                (2, "Empiler à une Pile"),
                (3, "Dépiler une pile"),
                (4, "Récuperer un élément à l'index"),
                (0, "Quitter")
            };
            List<(int num, string msg)> typeMenu = new() {
                (1, "String"),
                (2, "Decimal"),
                (3, "Personne"),
                (0, "Retour")
            };
            do
            {
                Menu.Classes.Menu.ShowMenu(mainMenu);
                int choice = Menu.Classes.Menu.AskMenuChoice(mainMenu);
                int typeChoice;
                switch (choice)
                {
                    case 1:
                        Menu.Classes.Menu.ShowMenu(typeMenu);
                        typeChoice = Menu.Classes.Menu.AskMenuChoice(typeMenu);
                        Console.Clear();
                        switch (typeChoice)
                        {
                            case 1:
                                ShowPile(names);
                                break;
                            case 2:
                                ShowPile(numbers);
                                break;
                            case 3:
                                ShowPile(personnes);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 2:
                        Menu.Classes.Menu.ShowMenu(typeMenu);
                        typeChoice = Menu.Classes.Menu.AskMenuChoice(typeMenu);
                        Console.Clear();
                        switch (typeChoice)
                        {
                            case 1:
                                string name = AskUserName();
                                PushToPile(names, name);
                                break;
                            case 2:
                                decimal number = AskUserNumber();
                                PushToPile(numbers, number);
                                break;
                            case 3:
                                var personneDetails = AskUserPersonneDetails();
                                Personne personne = new Personne(personneDetails.firstName, personneDetails.lastName, personneDetails.age);
                                PushToPile(personnes, personne);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 3:
                        Menu.Classes.Menu.ShowMenu(typeMenu);
                        typeChoice = Menu.Classes.Menu.AskMenuChoice(typeMenu);
                        Console.Clear();
                        switch (typeChoice)
                        {
                            case 1:
                                PopPile(names);
                                break;
                            case 2:
                                PopPile(numbers);
                                break;
                            case 3:
                                PopPile(personnes);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 4:
                        Menu.Classes.Menu.ShowMenu(typeMenu);
                        typeChoice = Menu.Classes.Menu.AskMenuChoice(typeMenu);
                        Console.Clear();
                        int index = AskUserIndex();
                        switch (typeChoice)
                        {
                            case 1:
                                GetFromPile(names, index);
                                break;
                            case 2:
                                GetFromPile(numbers, index);
                                break;
                            case 3:
                                GetFromPile(personnes, index);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void ShowPile<T>(PileArray<T> pile)
        {
            if (pile.isEmpty())
            {
                Console.WriteLine($"la liste est vide");
            }
            else
            {
                Console.WriteLine($"Affichage de la liste");
                foreach (T p in pile)
                {
                    Console.WriteLine(p);
                }
            }
        }

        private static void PushToPile<T>(PileArray<T> pile, T item)
        {
            pile.Push(item);
        }

        private static void PopPile<T>(PileArray<T> pile)
        {
            if (pile.isEmpty())
            {
                Console.WriteLine($"la liste est vide");
            } else
            {
                pile.Pop();
            }
        }

        private static T GetFromPile<T>(PileArray<T> pile, int index)
        {
            if (pile.isEmpty())
            {
                Console.WriteLine($"la liste est vide");
                return default(T);
            }
            else
            {
                try
                {
                    return pile.Get(index);
                } catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("L'index n'existe pas dans la pile");
                    return default(T);
                }
            }
        }

        private static string AskUserName()
        {
            string name;
            do
            {
                Console.Write("Donnez un nom à ajouter à la pile ? ");
                name = Console.ReadLine();
                if (name == null)
                {
                    Console.Write("Donnez un nom correct");
                }
            } while (name == null);
            return name;
        }

        private static decimal AskUserNumber()
        {
            bool isCorrect;
            decimal number;
            do
            {
                Console.Write("Donnez un nombre à ajouter à la pile ? ");
                isCorrect = decimal.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                {
                    Console.WriteLine("Rentrez un décimal correct");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return number;
        }

        private static (string firstName, string lastName, int age) AskUserPersonneDetails()
        {
            bool isCorrect;
            string firstName;
            do
            {
                Console.Write("Nom ? ");
                firstName = Console.ReadLine();
                if (firstName == null)
                {
                    Console.Write("Donnez un nom correct");
                }
            } while (firstName == null);

            string lastName;
            do
            {
                Console.Write("Prénom ? ");
                lastName = Console.ReadLine();
                if (lastName == null)
                {
                    Console.Write("Donnez un nom correct");
                }
            } while (lastName == null);

            int age;
            do
            {
                Console.Write("Age ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out age);
                if (!isCorrect || age < 1)
                {
                    Console.WriteLine("Rentrez un age supérieur ou égal à 1");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return (firstName, lastName, age);
        }

        private static int AskUserIndex()
        {
            bool isCorrect;
            int index;
            do
            {
                Console.Write("Index ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out index);
                if (!isCorrect || index < 1)
                {
                    Console.WriteLine("Rentrez un index supérieur ou égal à 0");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return index;
        }
    }
}
