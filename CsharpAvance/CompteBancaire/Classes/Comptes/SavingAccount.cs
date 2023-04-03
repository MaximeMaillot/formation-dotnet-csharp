using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes.Comptes
{
    internal class SavingAccount : BankAccount
    {
        private int _interestRatePct;
        public int InterestRatePct
        {
            get => _interestRatePct; set
            {
                if (value < 0)
                {
                    throw new Exception();
                } else
                {
                    _interestRatePct = value;
                }
            }
        }
        public SavingAccount(Client client, int interestRatePct) : base(client)
        {
            InterestRatePct = interestRatePct;
        }


        public override string ToString()
        {
            return $"Compte Epargne avex taux d'intérêts à {InterestRatePct}% : {base.ToString()} euros";
        }

        public int calculateInterest(int years)
        {
            int interest = 0;
            for (int i = 0; i < years; i++)
            {
                interest += (interest + Solde) * InterestRatePct / 100;
            }
            return interest;
        }
    }

}
