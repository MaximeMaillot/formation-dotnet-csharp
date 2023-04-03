using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class Operation
    {
        private static int _Number { get; set; } = 1;
        public int Number { get; set; }
        public int Amount { get; set; }
        public OperationStatus Status { get; set; }

        private Operation() {
            Number = _Number++;
        }
        public Operation(int amount, OperationStatus status):this()
        {
            Amount = amount;
            Status = status;
        }

        public override string ToString()
        {
            return $"Operation {Number} : {Status} de {Amount}";
        }
    }

    enum OperationStatus
    {
        Deposit = 0,
        Withdrawal = 1
    }
}
