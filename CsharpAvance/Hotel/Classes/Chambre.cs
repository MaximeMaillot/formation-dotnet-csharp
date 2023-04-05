namespace Hostel.Classes
{
    internal class Chambre
    {
        private Chambre()
        {
            Numero = ++NbChambres;
        }
        public Chambre(ChambreStatut statut, int nbLit, decimal tarif):this()
        {
            Statut = statut;
            NbLit = nbLit;
            Tarif = tarif;
        }
        private static int NbChambres { get; set; }
        public int Numero { get; private set; }
        public ChambreStatut Statut { get; private set; }
        public int NbLit { get; private set; }
        public decimal Tarif { get; private set; }

        public void UpdateChambreStatut(ChambreStatut statut)
        {
            Statut = statut;
        }

        public override string ToString()
        {
            return $"Chambre N°{Numero} qui a {NbLit} lit, à un tarf de {Tarif} euros et est {Statut}";
        }
    }

    public enum ChambreStatut
    {
        Libre,
        Occupe,
        EnNottoyage
    }
}
