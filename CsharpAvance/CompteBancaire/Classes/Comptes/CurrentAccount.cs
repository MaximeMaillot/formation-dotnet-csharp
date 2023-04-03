using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes.Comptes
{
    internal class CurrentAccount : BankAccount
    {
        public CurrentAccount(Client client) : base(client) { }
        public override string ToString()
        {
            return $"Compte Courant : {base.ToString()}";
        }
    }
}
