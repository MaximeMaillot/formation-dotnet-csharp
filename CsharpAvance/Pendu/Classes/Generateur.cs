using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendus.Classes
{
    internal static class Generateur
    {
        static string[] ListMot { get; } = { "Coucou" };

        public static string GenerateMot ()
        {
            Random random = new Random();
            return ListMot[random.Next(0, ListMot.Length)];
        }
    }
}
