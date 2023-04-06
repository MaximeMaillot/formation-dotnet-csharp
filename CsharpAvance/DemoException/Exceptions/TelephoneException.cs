using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoException.Exceptions
{
    internal class TelephoneException : Exception
    {
        public TelephoneException(string message = "Numéro de téléphone incorrect") : base(message)
        {
        }
    }
}
