using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Exceptions
{
    internal class UserInputException : Exception
    {
        public UserInputException(string msg = "La valeur saisie est incorrect") : base(msg) { }
    }
}
