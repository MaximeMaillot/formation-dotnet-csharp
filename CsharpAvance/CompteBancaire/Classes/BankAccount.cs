using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal abstract class BankAccount
    {
        private static int _Id { get; set; } = 1;
        public int Id { get; set; }
        public int Solde { get; set; } = 0;
        public Client Client { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        private BankAccount()
        {
            Id = _Id++;
        }
        public BankAccount (Client client) : this()
        {
            Client = client;
        }

        public override string ToString()
        {
            return $"numéro {Id} pour {Client.FirstName} {Client.LastName} à un solde de {Solde} euros";
        }

        public virtual void ShowAccount()
        {
            Console.WriteLine("Compte Bancaire : " + ToString());
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Dépôt négatif impossible");
            }
            Solde += amount;
            Operations.Add(new Operation(amount));
        }

        public void Withdrawal(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Retrait négatif impossible");
            }
            if (amount > Solde)
            {
                Console.WriteLine("Retrait impossible");
            }
            else
            {
                Solde -= amount;
                Operations.Add(new Operation(-amount));
            }
        }

        public void ShowOperations()
        {
            if (Operations.Count == 0)
            {
                Console.WriteLine("Pas d'operations sur ce compte bancaire");
            } else
            {
                Console.WriteLine("Liste des opérations");
                foreach (Operation operation in Operations)
                {
                    Console.WriteLine($"Operation N°{operation.Number} : {operation.Amount}");
                }
            }
        }
    }
}
