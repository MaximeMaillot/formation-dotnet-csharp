using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class CurrentAccount : BankAccount
    {
        public CurrentAccount(Client client) : base(client) { }
        public override void ShowAccount()
        {
            Console.WriteLine($"Compte Courant : " + base.ToString());
        }
    }
}
