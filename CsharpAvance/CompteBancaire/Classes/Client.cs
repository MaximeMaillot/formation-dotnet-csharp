using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }

        public Client(string firstName, string lastName, string telephoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
        }
    }
}
