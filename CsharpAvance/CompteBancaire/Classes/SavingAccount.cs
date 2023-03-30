using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class SavingAccount : BankAccount
    {
        public SavingAccount(Client client) : base(client) { }
        public override void ShowAccount()
        {
            Console.WriteLine($"Compte Epargne : " + base.ToString());
        }
    }
    
}
