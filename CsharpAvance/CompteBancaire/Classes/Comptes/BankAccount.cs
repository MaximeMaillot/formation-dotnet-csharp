using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes.Comptes
{
    internal abstract class BankAccount
    {
        private static int GlobalId { get; set; } = 1;
        public int Id { get; private set; }
        public int Solde { get; set; } = 0;
        public Client Client { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        private BankAccount()
        {
            Id = GlobalId++;
        }
        public BankAccount(Client client) : this()
        {
            Client = client;
        }

        public override string ToString()
        {
            return $"numéro {Id} pour {Client.FirstName} {Client.LastName} à un solde de {Solde} euros";
        }

        public (bool success, string errorMsg) Deposit(int amount)
        {
            if (amount < 0)
            {
                return (false, "Dépôt d'un montant négatif impossible");
            }
            Solde += amount;
            Operations.Add(new Operation(amount, OperationStatus.Deposit));
            return (true, "");
        }

        public virtual (bool success, string errorMsg) Withdrawal(int amount)
        {
            if (amount < 0)
            {
                return (false, "Retrait d'un montant négatif impossible");
            }
            if (amount > Solde)
            {
                return (false, "Solde insuffisant");
            }
            Solde -= amount;
            Operations.Add(new Operation(-amount, OperationStatus.Withdrawal));
            return (true, "");

        }
    }
}
