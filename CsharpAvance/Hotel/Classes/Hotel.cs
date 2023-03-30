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
        /// <summary>
        /// Add a client to the hostel
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            Clients.Add(client);
            Console.WriteLine("Client ajouté avec succès");
        }
        /// <summary>
        /// Show all clients in the hotel
        /// </summary>
        public void ShowClients()
        {
            if (!HasClients())
            {
                HotelConsole.WriteInColor("Pas de clients", ConsoleColor.Red);
                return;
            }
            foreach (Client client in Clients)
            {
                client.ShowClient();
            }
        }
        /// <summary>
        /// Show all reservations of a client
        /// </summary>
        /// <param name="client"></param>
        public void ShowReservationsByClient(Client client)
        {
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Client == client)
                {
                    reservation.ShowReservations();
                }
            }
        }
        /// <summary>
        /// Get all reservations of a client
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public List<Reservation> getReservationsByClientNumero(int numero)
        {
            return Reservations.FindAll((reservation) => reservation.Numero == numero);
        }
        /// <summary>
        /// Show all reservations of a client by its numero
        /// </summary>
        /// <param name="numero"></param>
        public void ShowReservationsByClientNumero(int numero)
        {
            List<Reservation> reservationList = getReservationsByClientNumero(numero);
            if (reservationList.Count == 0) {
                HotelConsole.WriteInColor("Aucune réservation pour ce client", ConsoleColor.Red);
                return;
            }
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Client.Numero == numero)
                {
                    reservation.ShowReservations();
                }
            }
        }
        /// <summary>
        /// Show all reservations
        /// </summary>
        public void ShowReservations()
        {
            if (!HasReservations())
            {
                HotelConsole.WriteInColor("Pas de réservations", ConsoleColor.Red);
            }
            foreach (Reservation reservation in Reservations)
            {
                reservation.ShowReservations();
            }
        }
        /// <summary>
        /// Add a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
            HotelConsole.WriteInColor("Reservation ajouté avec succès", ConsoleColor.Green);
        }
        /// <summary>
        /// Remove a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
            HotelConsole.WriteInColor("Reservation annulé avec succès", ConsoleColor.Green);
        }
        /// <summary>
        /// Add a chamber
        /// </summary>
        /// <param name="chambre"></param>
        public void AddChambre(Chambre chambre)
        {
            Chambres.Add(chambre);
        }

        /// <summary>
        /// Check if the hostel has clients
        /// </summary>
        /// <returns></returns>
        public bool HasClients()
        {
            return Clients.Count > 0;
        }
        /// <summary>
        /// Check if the hostel has reservations
        /// </summary>
        /// <returns></returns>
        public bool HasReservations()
        {
            return Reservations.Count > 0;
        }
        /// <summary>
        /// Check if the hostel has chambers
        /// </summary>
        /// <returns></returns>
        public bool hasChambres()
        {
            return Chambres.Count > 0;
        }
        /// <summary>
        /// Check if a client exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ClientExistsByNumero(int numero)
        {
            return Clients.Any(client => client.Numero == numero);
        }
        /// <summary>
        /// Check if a chamber exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ChambreExistsByNumero(int numero)
        {
            return Chambres.Any(chambre => chambre.Numero == numero);
        }
        /// <summary>
        /// Check if a reservation exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ReservationExistsByNumero(int numero)
        {
            return Reservations.Any(reservation => reservation.Numero == numero);
        }
        /// <summary>
        /// Get a chamber by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Chambre GetChambreByNumero(int numero)
        {
            return Chambres.Find((chambre) => chambre.Numero == numero);
        }
        /// <summary>
        /// Get a reservation by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Reservation GetReservationByNumero(int numero)
        {
            return Reservations.Find((reservation) => reservation.Numero == numero);
        }
        /// <summary>
        /// Get a client by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Client GetClientByNumero(int numero)
        {
            return Clients.Find((client) => client.Numero == numero);
        }
    }
}
