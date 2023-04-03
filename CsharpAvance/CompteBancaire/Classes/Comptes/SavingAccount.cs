using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes.Comptes
{
    internal class SavingAccount : BankAccount
    {
        private float _interestRatePct;
        public float InterestRatePct
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
        public SavingAccount(Client client, float interestRatePct) : base(client)
        {
            InterestRatePct = interestRatePct;
        }


        public override string ToString()
        {
            return $"Compte Epargne avex taux d'intérêts à {InterestRatePct}% : {base.ToString()} euros";
        }

        public decimal CalculateInterest(int years)
        {
            decimal interest = 0m;
            for (int i = 0; i < years; i++)
            {
                interest += (interest + Solde) * (decimal)InterestRatePct / 100m;
            }
            return interest;
        }
    }

}
