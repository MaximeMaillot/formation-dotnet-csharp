namespace Hostel.Classes
{
    internal class Hotel
    {
        public string NomHotel { get; set; }
        public List<Client> ClientsHotel { get; private set; } = new List<Client>();
        public List<Reservation> ReservationsHotel { get; private set; } = new List<Reservation>();
        public List<Chambre> ChambresHotel { get; private set; } = new List<Chambre>();
        public Hotel(string nom)
        {
            NomHotel = nom;
            Random r = new Random();
            for (int i = 0; i < 30; i++)
            {
                AddChambre(new Chambre(r.Next(1,5), r.Next(25,151)));
            }
        }

        /// <summary>
        /// Add a client to the hostel
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            ClientsHotel.Add(client);
        }

        public List<Reservation> GetReservationsByClient(Client client)
        {
            return ReservationsHotel.Where(reservation =>  reservation.ClientReservation == client).ToList();
        }

        /// <summary>
        /// Add a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            ReservationsHotel.Add(reservation);
        }

        public void CancelReservation(int numero)
        {
            int index = ReservationsHotel.FindIndex(r => r.NumeroReservation == numero);
            if (index == -1)
            {
                throw new Exception("Reservation not found");
            }
            else
            {
                // Remboursement
                ReservationsHotel[index].Cancel();
            }
        }

        public void EndReservation(int numero)
        {
            int index = ReservationsHotel.FindIndex(r => r.NumeroReservation == numero);
            if (index == -1)
            {
                throw new Exception("Reservation not found");
            }
            else
            {
                // Payement
                ReservationsHotel[index].End();
            }
        }

        public void CleanChambre(int numero)
        {
            Chambre chambre = ChambresHotel.Find(c =>  c.NumeroChambre == numero);
            if (chambre == null)
            {
                throw new Exception("Chambre not found");
            }
            else if (chambre.StatutChambre != ChambreStatut.EnNottoyage)
            {
                throw new Exception($"Chambre not {ChambreStatut.EnNottoyage}");
            }
            else
            {
                chambre.UpdateChambreStatut(ChambreStatut.Libre);
            }
        }

        public List<Chambre> GetChambresAvailableByNbLit(int nbLit)
        {
            List<Chambre> chambres = ChambresHotel.FindAll(chambre => (chambre.NbLit >= nbLit && chambre.StatutChambre == ChambreStatut.Libre));
            chambres.Sort((c1, c2) =>  c1.NbLit - c2.NbLit);
            return chambres;
        }

        /// <summary>
        /// Add a chamber
        /// </summary>
        /// <param name="chambre"></param>
        public void AddChambre(Chambre chambre)
        {
            ChambresHotel.Add(chambre);
        }

        /// <summary>
        /// Check if the hostel has clients
        /// </summary>
        /// <returns></returns>
        public bool HasClient()
        {
            return ClientsHotel.Count > 0;
        }

        /// <summary>
        /// Check if the hostel has reservations
        /// </summary>
        /// <returns></returns>
        public bool HasReservation()
        {
            return ReservationsHotel.Count > 0;
        }

        /// <summary>
        /// Check if the hostel has chambers
        /// </summary>
        /// <returns></returns>
        public bool HasChambre()
        {
            return ChambresHotel.Count > 0;
        }

        public bool HasChambreOpen()
        {
            return ChambresHotel.Any(chambre => chambre.StatutChambre == ChambreStatut.Libre);
        }

        public int GetNbChambreOpen() 
        {
            return ChambresHotel.Count(chambre => chambre.StatutChambre == ChambreStatut.Libre);
        }

        /// <summary>
        /// Check if a client exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ClientExistsByNumero(int numero)
        {
            return ClientsHotel.Any(client => client.Numero == numero);
        }

        /// <summary>
        /// Check if a chamber exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ChambreExistsByNumero(int numero)
        {
            return ChambresHotel.Any(chambre => chambre.NumeroChambre == numero);
        }

        /// <summary>
        /// Check if a reservation exist
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ReservationExistsByNumero(int numero)
        {
            return ReservationsHotel.Any(reservation => reservation.NumeroReservation == numero);
        }

        /// <summary>
        /// Get a chamber by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Chambre GetChambreByNumero(int numero)
        {
            return ChambresHotel.Find((chambre) => chambre.NumeroChambre == numero);
        }

        /// <summary>
        /// Get a reservation by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Reservation GetReservationByNumero(int numero)
        {
            return ReservationsHotel.Find((reservation) => reservation.NumeroReservation == numero);
        }

        /// <summary>
        /// Get a client by its numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Client GetClientByNumero(int numero)
        {
            return ClientsHotel.Find((client) => client.Numero == numero);
        }
    }
}
