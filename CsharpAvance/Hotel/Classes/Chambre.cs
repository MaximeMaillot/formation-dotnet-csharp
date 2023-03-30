namespace Hostel.Classes
{
    internal class Chambre
    {
        private Chambre()
        {
            Numero = NumeroStatic++;
        }
        public Chambre(string statut, int nbLit, float tarif):this()
        {
            Statut = statut;
            NbLit = nbLit;
            Tarif = tarif;
        }
        private static int NumeroStatic { get; set; } = 1;
        public int Numero { get; set; }
        public string Statut { get; set; }
        public int NbLit { get; set; }
        public float Tarif { get; set; }
    }
}
