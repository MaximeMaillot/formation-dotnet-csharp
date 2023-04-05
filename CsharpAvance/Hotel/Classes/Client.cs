namespace Hostel.Classes
{
    internal class Client
    {
        private Client()
        {
            Numero = ++NbClients;
        }
        public Client(string nom, string prenom, string numTel):this()
        {
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
        }
        private static int NbClients { get; set; }
        public int Numero { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NumTel{get;set;}

        public override string ToString()
        {
            return $"Client N°{Numero} : {Prenom} {Nom}, Téléphone : {NumTel}";
        }
    }
}
