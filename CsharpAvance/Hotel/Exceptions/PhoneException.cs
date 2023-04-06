using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Exceptions
{
    internal class PhoneException : Exception
    {
        public PhoneException(string msg = "Le numéro de téléphone est incorrect"):base(msg) { }
    }
}
