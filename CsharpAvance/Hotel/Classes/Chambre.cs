namespace Hostel.Classes
{
    internal class Chambre
    {
        private Chambre()
        {
            NumeroChambre = ++NbChambres;
        }
        public Chambre(int nbLit, decimal tarif, ChambreStatut statut = ChambreStatut.Libre) :this()
        {
            NbLit = nbLit;
            Tarif = tarif;
            StatutChambre = statut;
        }
        private static int NbChambres { get; set; }
        public int NumeroChambre { get; private set; }
        public ChambreStatut StatutChambre { get; private set; }
        public int NbLit { get; private set; }
        public decimal Tarif { get; private set; }

        public void UpdateChambreStatut(ChambreStatut statut)
        {
            StatutChambre = statut;
        }

        public override string ToString()
        {
            return $"Chambre N°{NumeroChambre} qui a {NbLit} lit, à un tarif de {Tarif} euros et est {StatutChambre}";
        }
    }

    public enum ChambreStatut
    {
        Libre,
        Occupe,
        EnNottoyage
    }
}
