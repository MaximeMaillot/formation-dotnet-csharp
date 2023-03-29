namespace Hostel.Classes
{
    internal class Client
    {
        public Client(string nom, string prenom, string numTel)
        {
            Numero++;
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
        }
        public static int Numero { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NumTel{get;set;}
    }
}
