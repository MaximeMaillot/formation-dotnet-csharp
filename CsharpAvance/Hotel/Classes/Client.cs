using Hostel.Exceptions;

namespace Hostel.Classes
{
    internal class Client
    {
        private int _numero;
        private string _nom;
        private string _prenom;
        private string _numTel;
        private Client()
        {
            Numero = ++NbClients;
        }
        public Client(string nom, string prenom, string numTel) : this()
        {
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
        }
        private static int NbClients { get; set; }
        public int Numero
        {
            get => _numero; set
            {
                if (value < 0)
                {
                    new UserInputException("Le numéro du client doit être supérieur à 0");
                }
                _numero = value;
            }
        }
        public string Nom
        {
            get => _nom; set
            {
                if (value == null)
                {
                    new UserInputException("Entrez un nom correct");
                }
                _nom = value;
            }
        }

        public string Prenom
        {
            get => _prenom; set
            {
                if (value == null)
                {
                    new UserInputException("Entrez un prénom correct");
                }
                _prenom = value;
            }
        }

        public string NumTel
        {
            get => _numTel; set
            {
                if (!value.StartsWith("0"))
                {
                    throw new PhoneException("Le numéro de téléphone doit commencer par 0");
                }
                else if (value.Length != 10)
                {
                    throw new PhoneException("Le numéro de téléphone doit faire 10 caractères");
                }
                _numTel = value;
            }
        }

        public override string ToString()
        {
            return $"Client N°{Numero} : {Prenom} {Nom}, Téléphone : {NumTel}";
        }
    }
}
