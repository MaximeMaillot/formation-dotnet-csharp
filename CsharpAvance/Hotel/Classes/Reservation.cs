namespace Hostel.Classes
{
    internal class Reservation
    {
        private static int NbReservations { get; set; }
        public int Numero { get; set; }
        public ReservationStatut Statut { get; set; }
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();
        public Client Client { get; set; }
        private Reservation()
        {
            Numero = ++NbReservations;
        }
        private Reservation(Client client, ReservationStatut statut) :this()
        {
            Statut = statut;
            Client = client;
        }
        public Reservation(List<Chambre> chambres, Client client, ReservationStatut statut = ReservationStatut.Prevu) :this(client, statut) 
        {
            if (Chambres.All(chambre => chambre.Statut == ChambreStatut.Libre))
            {
                Chambres = chambres;
                foreach (var chambre in Chambres)
                {
                    chambre.UpdateChambreStatut(ChambreStatut.Occupe);
                }
            } else
            {
                throw new Exception("All chambres are not open");
            }
        }
        public Reservation(Chambre chambre, Client client, ReservationStatut statut = ReservationStatut.Prevu ) :this(client, statut)
        {
            if (chambre.Statut != ChambreStatut.Libre)
            {
                throw new Exception("Chambre is not open");
            } else
            {
                Chambres.Add(chambre);
                chambre.UpdateChambreStatut(ChambreStatut.Occupe);
            }
        }

        public void Cancel()
        {
            Statut = ReservationStatut.Annule;
            foreach (var chambre in Chambres)
            {
                chambre.UpdateChambreStatut(ChambreStatut.Libre);
            }
        }

        public void End()
        {
            Statut = ReservationStatut.Fini;
            foreach (var chambre in Chambres)
            {
                chambre.UpdateChambreStatut(ChambreStatut.EnNottoyage);
            }
        }

        public decimal GetReservationPrixTotal()
        {
            decimal prixTotal = 0;
            foreach (var chambre in Chambres)
            {
                prixTotal += chambre.Tarif;
            }
            return prixTotal;
        }

        public override string ToString()
        {
            return $"Reservation N°{Numero} avec statut {Statut} avec un prix total de {GetReservationPrixTotal()} euros";
        }
    }
    public enum ReservationStatut {
        Prevu,
        EnCours,
        Fini,
        Annule
    }
}
