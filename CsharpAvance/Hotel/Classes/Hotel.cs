namespace Hostel.Classes
{
    internal class Hotel
    {
        public Hotel(string nom)
        {
            Nom = nom;
            Console.WriteLine($"{nom} a été créer avec succès !");
        }
        public string Nom { get; set; }
        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<Reservation> Reservations { get; private set; } = new List<Reservation>();
        public List<Chambre> Chambres { get; private set; } = new List<Chambre>();

        public void AddClient(Client client)
        {
            Clients.Add(client);
            Console.WriteLine("Client ajouté avec succès");
        }

        public void ShowClients()
        {
            foreach (Client client in Clients)
            {
                client.ShowClient();
            }
        }

        public void ShowReservationByClient(Client client)
        {
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Client == client)
                {
                    reservation.ShowReservation();
                }
            }
        }

        public List<Reservation> getReservationByClientNumero(int numero)
        {
            return Reservations.FindAll((reservation) => reservation.Numero == numero);
        }
        public void ShowReservationByClientNumero(int numero)
        {
            List<Reservation> reservationList = getReservationByClientNumero(numero);
            if (reservationList.Count == 0) {
                HotelConsole.WriteInColor("Aucune réservation pour ce client", ConsoleColor.Red);
                return;
            }
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Client.Numero == numero)
                {
                    reservation.ShowReservation();
                }
            }
        }
        public void ShowReservations()
        {
            if (!HasReservations())
            {
                HotelConsole.WriteInColor("Pas de réservations", ConsoleColor.Red);
            }
            foreach (Reservation reservation in Reservations)
            {
                reservation.ShowReservation();
            }
        }

        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
            HotelConsole.WriteInColor("Reservation ajouté avec succès", ConsoleColor.Green);
        }

        public void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
            HotelConsole.WriteInColor("Reservation annulé avec succès", ConsoleColor.Green);
        }

        public void AddChambre(Chambre chambre)
        {
            Chambres.Add(chambre);
        }

        public bool HasClients()
        {
            return Clients.Count > 0;
        }

        public bool HasReservations()
        {
            return Reservations.Count > 0;
        }

        public bool hasChambres()
        {
            return Chambres.Count > 0;
        }

        public bool ClientExistsByNumero(int numero)
        {
            return Clients.Any(client => client.Numero == numero);
        }
        public bool ChambreExistsByNumero(int numero)
        {
            return Chambres.Any(chambre => chambre.Numero == numero);
        }

        public bool ReservationExistsByNumero(int numero)
        {
            return Reservations.Any(reservation => reservation.Numero == numero);
        }

        public Chambre GetChambreByNumero(int numero)
        {
            return Chambres.Find((chambre) => chambre.Numero == numero);
        }

        public Reservation GetReservationByNumero(int numero)
        {
            return Reservations.Find((reservation) => reservation.Numero == numero);
        }

        public Client GetClientByNumero(int numero)
        {
            return Clients.Find((client) => client.Numero == numero);
        }
    }
}
