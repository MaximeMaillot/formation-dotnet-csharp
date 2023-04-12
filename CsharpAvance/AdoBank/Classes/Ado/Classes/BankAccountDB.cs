using CompteBancaire.Classes;
using Helper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoBank.Classes.Ado.Filters
{
    internal class BankAccountDB : AdoDBClass
    {
        public int? account_id { get; set; }
        public decimal? solde { get; set; }
        public int? client_id { get; set; }
    }
}
