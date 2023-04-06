using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Exceptions
{
    internal class HotelException : Exception
    {
        public HotelException(string message = "Problème survenu lors de la modification de l'hôtel"): base(message) { }
    }
}
