using System;
using CompteBancaire.Classes.Comptes;

namespace CompteBancaire.Classes
{
    internal static class Main
    {
        public static void Start()
        {
            List<(int num, string msg, Action action)> mainMenu = new() {
                (1, "Lister les comptes bancaires", ShowBankAccounts),
                (2, "Créer un client", () => {}),
                (3, "Créer un compte", () => {}),
                (0, "Quitter", null)
            };

            Menu.Classes.Menu.HandleIHM(mainMenu);
        }

        public static void ShowBankAccounts()
        {
            List<BankAccount> bankAccounts = BankAccount.GetBankAccounts();
            Console.WriteLine("Liste des comptes en banque : ");
            foreach(BankAccount bankAccount in bankAccounts)
            {
                Console.WriteLine(bankAccount);
            }
        }

        public static void CreateAccount()
        {

        }
    }
}
