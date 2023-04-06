namespace Hostel.Classes
{
    internal class Reservation
    {
        private static int NbReservations { get; set; }
        public int NumeroReservation { get; private set; }
        public ReservationStatut StatutReservation { get; private set; }
        public List<Chambre> ChambresReservations { get; private set; } = new List<Chambre>();
        public Client ClientReservation { get; private set; }
        private Reservation()
        {
            NumeroReservation = ++NbReservations;
        }
        private Reservation(Client client, ReservationStatut statut) :this()
        {
            StatutReservation = statut;
            ClientReservation = client;
        }
        public Reservation(List<Chambre> chambres, Client client, ReservationStatut statut = ReservationStatut.Prevu) :this(client, statut) 
        {
            if (ChambresReservations.All(chambre => chambre.StatutChambre == ChambreStatut.Libre))
            {
                ChambresReservations = chambres;
                foreach (var chambre in ChambresReservations)
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
            if (chambre.StatutChambre != ChambreStatut.Libre)
            {
                throw new Exception("Chambre is not open");
            } else
            {
                ChambresReservations.Add(chambre);
                chambre.UpdateChambreStatut(ChambreStatut.Occupe);
            }
        }

        public void Cancel()
        {
            StatutReservation = ReservationStatut.Annule;
            foreach (var chambre in ChambresReservations)
            {
                chambre.UpdateChambreStatut(ChambreStatut.Libre);
            }
        }

        public void End()
        {
            StatutReservation = ReservationStatut.Fini;
            foreach (var chambre in ChambresReservations)
            {
                chambre.UpdateChambreStatut(ChambreStatut.EnNottoyage);
            }
        }

        public decimal GetReservationPrixTotal()
        {
            decimal prixTotal = 0;
            foreach (var chambre in ChambresReservations)
            {
                prixTotal += chambre.Tarif;
            }
            return prixTotal;
        }

        public override string ToString()
        {
            return $"Reservation N°{NumeroReservation} avec statut {StatutReservation} avec un prix total de {GetReservationPrixTotal()} euros";
        }
    }
    public enum ReservationStatut {
        Prevu,
        EnCours,
        Fini,
        Annule
    }
}
