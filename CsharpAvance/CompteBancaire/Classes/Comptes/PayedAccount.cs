using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes.Comptes
{
    internal class PayedAccount : BankAccount
    {
        private int _tax;
        public int Tax
        {
            get => _tax; set
            {
                if (value < 0)
                {
                    throw new Exception();
                } else
                {
                    _tax = value;
                }
            }
        }
        public PayedAccount(Client client, int tax) : base(client)
        {
            Tax = tax;
        }

        public override string ToString()
        {
            return $"Compte Payant avec taxe de {Tax} : {base.ToString()}";
        }

        public override (bool, string) Withdrawal(int amount)
        {
            return base.Withdrawal(amount + Tax);
        }
    }
}
