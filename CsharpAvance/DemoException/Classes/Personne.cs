using DemoException.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoException.Classes
{
    internal class Personne
    {
        private string _telephone;

        public Personne(string telephone)
        {
            Telephone = telephone;
        }

        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                if (!value.StartsWith("0")) {
                    throw new TelephoneException("Le numéro de téléphone doit commencer par 0");
                } else if (value.Length != 10) {
                    throw new TelephoneException("Le numéro de téléphone doit faire 10 caractères");
                }
                _telephone = value;
            }
        }

        

    }
}
