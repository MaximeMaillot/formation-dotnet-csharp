using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal static class Main
    {
        public static void Start()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            do
            {
                Console.WriteLine("=== Menu Principal ===\n");
                Console.WriteLine("1. Lister les comptes bancaires");
                Console.WriteLine("2. Créer un compte bancaire");
                Console.WriteLine("3. Effectuer un dépôt");
                Console.WriteLine("4. Effectuer un retrait");
                Console.WriteLine("5. Afficher les opérations et le solde");
                Console.WriteLine("0. Quitter le programme");
                int choice, compteId, index;
                bool isCorrect;
                do
                {
                    Console.Write("Votre choix : ");
                    isCorrect = int.TryParse(Console.ReadLine(), out choice);
                } while (!isCorrect);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("Aucun compte");
                        }
                        else
                        {
                            foreach (BankAccount account in accounts)
                            {
                                account.ShowAccount();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n=== Création de compte ===\n");
                        Console.WriteLine("1. Compte Courant");
                        Console.WriteLine("2. Compte Epargne");
                        Console.WriteLine("3. Compte Payant");
                        do
                        {
                            Console.Write("Votre choix : ");
                            isCorrect = int.TryParse(Console.ReadLine(), out choice);
                            if (!isCorrect || choice < 0 || choice > 3)
                            {
                                Console.WriteLine("Choisissez une valeur correct");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        switch (choice)
                        {
                            case 1:
                                accounts.Add(new CurrentAccount(AskClientDetails()));
                                break;
                            case 2:
                                accounts.Add(new SavingAccount(AskClientDetails()));
                                break;
                            case 3:
                                accounts.Add(new PayedAccount(AskClientDetails()));
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 3:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        do
                        {
                            Console.Write("Quel compte souhaitez-vous créditer ? ");
                            isCorrect = int.TryParse(Console.ReadLine(), out compteId);
                            index = accounts.FindIndex((account) => account.Id == compteId);
                            if (!isCorrect)
                            {
                                Console.WriteLine("Rentrez un numéro de compte correct");
                            }
                            if (index < 0)
                            {
                                Console.WriteLine("le compte n'existe pas");
                            }
                        } while (!isCorrect);
                        int deposit;
                        do
                        {
                            Console.Write("Combien voulez-vous déposer (entrez un nombre entier) : ");
                            isCorrect = int.TryParse(Console.ReadLine(), out deposit);
                            if (!isCorrect || deposit <= 0)
                            {
                                Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        accounts[index].Deposit(deposit);
                        break;
                    case 4:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        do
                        {
                            Console.Write("Quel compte souhaitez-vous débiter ? ");
                            isCorrect = int.TryParse(Console.ReadLine(), out compteId);
                            index = accounts.FindIndex((account) => account.Id == compteId);
                            if (!isCorrect)
                            {
                                Console.WriteLine("Rentrez un numéro de compte correct");
                            }
                            else if (index < 0)
                            {
                                Console.WriteLine("le compte n'existe pas");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        int withdrawal;
                        do
                        {
                            Console.Write("Combien voulez-vous retirer (entrez un nombre entier) : ");
                            isCorrect = int.TryParse(Console.ReadLine(), out withdrawal);
                            if (!isCorrect || withdrawal <= 0)
                            {
                                Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                            }
                            else if (index < 0)
                            {
                                Console.WriteLine("le compte n'existe pas");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        accounts[index].Withdrawal(withdrawal);
                        break;
                    case 5:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        do
                        {
                            Console.Write("Entrez l'identifiant du compte bancaire : ");
                            isCorrect = int.TryParse(Console.ReadLine(), out compteId);
                            index = accounts.FindIndex((account) => account.Id == compteId);
                            if (!isCorrect)
                            {
                                Console.WriteLine("Choisissez une valeur correct");
                            }
                            else if (index < 0)
                            {
                                Console.WriteLine("le compte n'existe pas");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                        accounts[index].ShowOperations();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Faut choisir une bonne valeur wallah");
                        break;
                }
            } while (true);
        }
        private static Client AskClientDetails()
        {
            bool isCorrect;
            Console.Write("Quel est le prénom du client ? ");
            string firstName = Console.ReadLine();
            Console.Write("Quel est le nom du client ? ");
            string lastName = Console.ReadLine();
            string phone;
            do
            {
                Console.Write("Quel est le numéro de téléphone du client ? ");
                phone = Console.ReadLine();
                isCorrect = int.TryParse(phone, out _) && phone.Length == 10;
                if (!isCorrect)
                {
                    Console.WriteLine("Un numéro de téléphone est composé de 10 chiffres");
                }
            } while (!isCorrect);
            return new Client(firstName, lastName, phone);
        }
    }
}
