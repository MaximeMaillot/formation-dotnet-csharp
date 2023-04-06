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
        /// <exception cref="UserInputException">This exception is thrown if the input of the user is incorrect</exception>
        /// <exception cref="PhoneException">This exception is thrown if the phone number is incorrect</exception>
        public Client(string nom, string prenom, string numTel) : this()
        {
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
        }
        private static int NbClients { get; set; }
        public int Numero
        {
            get => _numero; private set
            {
                if (value < 0)
                {
                    throw new UserInputException("Le numéro du client doit être supérieur à 0");
                }
                _numero = value;
            }
        }
        public string Nom
        {
            get => _nom; private set
            {
                _nom = value ?? throw new UserInputException("Entrez un nom correct");
            }
        }

        public string Prenom
        {
            get => _prenom; private set
            {
                _prenom = value ?? throw new UserInputException("Entrez un prénom correct");
            }
        }

        public string NumTel
        {
            get => _numTel; private set
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
