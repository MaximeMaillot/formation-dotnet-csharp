namespace Hostel.Classes
{
    internal class Hotel
    {
        public Hotel(string nom)
        {
            Nom = nom;
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
        }

        public List<Reservation> GetReservationsByClient(Client client)
        {
            return Reservations.Where(reservation =>  reservation.Client == client).ToList();
        }

        /// <summary>
        /// Add a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        /// <summary>
        /// Remove a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
        }

        public void CancelReservation(Reservation reservation)
        {
            int index = Reservations.FindIndex(r => r.Numero == reservation.Numero);
            if (index == -1)
            {
                throw new Exception("Reservation not found");
            } else
            {
                Reservations[index].Cancel();
            }
        }

        public void CancelReservation(int numero)
        {
            int index = Reservations.FindIndex(r => r.Numero == numero);
            if (index == -1)
            {
                throw new Exception("Reservation not found");
            }
            else
            {
                Reservations[index].Cancel();
            }
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
        public bool HasClient()
        {
            return Clients.Count > 0;
        }

        /// <summary>
        /// Check if the hostel has reservations
        /// </summary>
        /// <returns></returns>
        public bool HasReservation()
        {
            return Reservations.Count > 0;
        }

        /// <summary>
        /// Check if the hostel has chambers
        /// </summary>
        /// <returns></returns>
        public bool HasChambre()
        {
            return Chambres.Count > 0;
        }

        public bool HasChambreOpen()
        {
            return Chambres.Any(chambre => chambre.Statut == ChambreStatut.Libre);
        }

        public int GetNbChambreOpen() 
        {
            return Chambres.Count(chambre => chambre.Statut == ChambreStatut.Libre);
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
