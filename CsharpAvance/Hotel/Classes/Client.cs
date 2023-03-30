namespace Hostel.Classes
{
    internal class Client
    {
        private Client()
        {
            Numero = NumeroStatic++;
        }
        public Client(string nom, string prenom, string numTel):this()
        {
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
        }
        private static int NumeroStatic { get; set; } = 1;
        public int Numero { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NumTel{get;set;}

        public void ShowClient()
        {
            Console.WriteLine($"Client N°{Numero} : {Prenom} {Nom}, Téléphone : {NumTel}");
        }
    }
}
