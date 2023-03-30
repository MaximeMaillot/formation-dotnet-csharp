using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class PayedAccount : BankAccount
    {
        public PayedAccount(Client client) : base(client) { }
        public override void ShowAccount()
        {
            Console.WriteLine($"Compte Payant : " + base.ToString());
        }
    }
}
