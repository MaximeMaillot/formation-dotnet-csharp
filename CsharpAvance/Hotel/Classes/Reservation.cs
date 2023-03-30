namespace Hostel.Classes
{
    internal class Reservation
    {
        private static int NumeroStatic { get; set; } = 1;
        public int Numero { get; set; }
        public string Statut { get; set; }
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();
        public Client Client { get; set; }
        private Reservation()
        {
            Numero = NumeroStatic++;
        }
        private Reservation(Client client, string statut) :this()
        {
            Statut = statut;
            Client = client;
        }
        public Reservation(List<Chambre> chambres, Client client, string statut = "Open") :this(client, statut) 
        {
            Chambres = chambres;
        }
        public Reservation(Chambre chambre, Client client, string statut = "Open") :this(client, statut)
        {
            Chambres.Add(chambre);
        }

        /// <summary>
        /// Show the chambers reserved by the client
        /// </summary>
        public void ShowReservations()
        {
            if (Chambres.Count == 0) {
                HotelConsole.WriteInColor("Pas de réservations", ConsoleColor.Red);
                return;
            }
            Console.WriteLine($"Pour le Client N°{Client.Numero} :");
            foreach (Chambre chambre in Chambres)
            {
                Console.WriteLine($"\tReservation N°{Numero} avec pour statut : {Statut} ");
            }
        }
    }
}
