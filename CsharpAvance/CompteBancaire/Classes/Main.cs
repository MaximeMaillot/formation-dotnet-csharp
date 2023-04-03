using System;
using CompteBancaire.Classes.Comptes;

namespace CompteBancaire.Classes
{
    internal static class Main
    {
        public static void Start()
        {
            List<BankAccount> accounts = new();
            List<(int num, string msg)> mainMenu = new() {
                (1, "Lister les comptes bancaires"),
                (2, "Créer un compte bancaire"),
                (3, "Effectuer un dépôt"),
                (4, "Effectuer un retrait"),
                (5, "Afficher les opérations et le solde"),
                (6, "Récupérer les intérêts d'un compte"),
                (0, "Quitter")
            };
            List<(int num, string msg)> accountMenu = new() {
                (1, "Compte courant"),
                (2, "Compte épargne"),
                (3, "Compte payant"),
                (0, "Retour")
            };

            do
            {
                Menu.Classes.Menu.ShowMenu(mainMenu, "=== Menu Principal ===\n");
                int choice = Menu.Classes.Menu.AskMenuChoice(mainMenu);
                int compteId, index;
                bool isCorrect;
                (bool success, string errorMsg) result;
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        if (IsAccountsEmpty(accounts))
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        else
                        {
                            foreach (BankAccount account in accounts)
                            {
                                Console.WriteLine(account);
                                //account.ShowAccount();
                            }
                        }
                        break;
                    case 2:
                        Menu.Classes.Menu.ShowMenu(accountMenu, "\n=== Création de compte ===\n");
                        choice = Menu.Classes.Menu.AskMenuChoice(accountMenu);
                        (string firstName, string lastName, string phone) accountDetails;
                        switch (choice)
                        {
                            case 1:
                                accountDetails = AskClientDetails();
                                accounts.Add(new CurrentAccount(new Client(accountDetails.firstName, accountDetails.lastName, accountDetails.phone)));
                                break;
                            case 2:
                                accountDetails = AskClientDetails();
                                accounts.Add(new SavingAccount(new Client(accountDetails.firstName, accountDetails.lastName, accountDetails.phone), AskUserInterestRate()));
                                break;
                            case 3:
                                accountDetails = AskClientDetails();
                                accounts.Add(new PayedAccount(new Client(accountDetails.firstName, accountDetails.lastName, accountDetails.phone), AskUserTax()));
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 3:
                        if (IsAccountsEmpty(accounts))
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        index = AskUserAccountId(accounts);
                        result = accounts[index].Deposit(AskUserDeposit());
                        if (!result.success)
                        {
                            Console.WriteLine(result.errorMsg);
                        }
                        break;
                    case 4:
                        if (IsAccountsEmpty(accounts))
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        index = AskUserAccountId(accounts);
                        result = accounts[index].Withdrawal(AskUserWithdrawal());
                        if (!result.success)
                        {
                            Console.WriteLine(result.errorMsg);
                        }
                        break;
                    case 5:
                        if (IsAccountsEmpty(accounts))
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        index = AskUserAccountId(accounts);
                        if (accounts[index].Operations.Count == 0)
                        {
                            Console.WriteLine("Pas d'operations sur ce compte bancaire");
                            break;
                        }

                        Console.WriteLine("Liste des opérations");
                        foreach (Operation operation in accounts[index].Operations)
                        {
                            Console.WriteLine(operation.ToString());
                        }
                        break;
                    case 6:
                        if (IsAccountsEmpty(accounts))
                        {
                            Console.WriteLine("Aucun compte");
                            break;
                        }
                        index = AskUserAccountId(accounts);
                        if (accounts[index].GetType() != typeof(SavingAccount))
                        {
                            Console.WriteLine("Calcul d'intérêt disponible que sur les comptes épargnes");
                            break;
                        }
                        int years = AskUserNbYears();
                        SavingAccount epargne = (SavingAccount)accounts[index];
                        Console.WriteLine($"Intérêts au bout de {years} ans sur ce compte épargne : {epargne.calculateInterest(years)}");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Faut choisir une bonne valeur");
                        break;
                }
            } while (true);
        }
        private static (string, string, string) AskClientDetails()
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
            return (firstName, lastName, phone);
        }

        private static bool IsAccountsEmpty(List<BankAccount> accounts)
        {
            return accounts.Count == 0;
        }

        private static int AskUserWithdrawal()
        {
            int withdrawal;
            bool isCorrect;
            do
            {
                Console.Write("Combien voulez-vous retirer (entrez un nombre entier) : ");
                isCorrect = int.TryParse(Console.ReadLine(), out withdrawal);
                if (!isCorrect || withdrawal <= 0)
                {
                    Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                }
            } while (!isCorrect);
            return withdrawal;
        }

        private static int AskUserDeposit()
        {
            bool isCorrect;
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
            return deposit;
        }

        private static int AskUserAccountId(List<BankAccount> accounts)
        {
            bool isCorrect;
            int index, compteId;
            do
            {
                Console.Write("Numéro du compte ? ");
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
            return index;
        }

        private static int AskUserInterestRate()
        {
            bool isCorrect;
            int interestRate;
            do
            {
                Console.Write("Quel est le taux d'intérêts du compte épargne ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out interestRate);
                if (!isCorrect || interestRate <= 0)
                {
                    Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return interestRate;
        }

        private static int AskUserTax()
        {
            bool isCorrect;
            int tax;
            do
            {
                Console.Write("Quel est la taxe de retrait sur le compte payant ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out tax);
                if (!isCorrect || tax <= 0)
                {
                    Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return tax;
        }

        private static int AskUserNbYears()
        {
            bool isCorrect;
            int years;
            do
            {
                Console.Write("Combien d'années d'intérêts voulez-vous calculer ? ");
                isCorrect = int.TryParse(Console.ReadLine(), out years);
                if (!isCorrect || years <= 0)
                {
                    Console.WriteLine("Rentrez un chiffre supérieur ou égal à 0");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return years;
        }
    }
}
