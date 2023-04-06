using Hostel.Exceptions;

namespace Hostel.Classes
{
    internal class Chambre
    {
        private int _nbChambres;
        private int _nbLit;
        private decimal _tarif;
        private int _numeroChambre;
        private Chambre()
        {
            NumeroChambre = ++NbChambres;
        }
        public Chambre(int nbLit, decimal tarif, ChambreStatut statut = ChambreStatut.Libre) : this()
        {
            NbLit = nbLit;
            Tarif = tarif;
            StatutChambre = statut;
        }
        public int NbChambres
        {
            get => _nbChambres;
            set
            {
                if (value < 0)
                {
                    throw new UserInputException("Nombre de chambres inférieur à 0");
                }
                _nbChambres = value;
            }
        }
        public int NumeroChambre
        {
            get => _numeroChambre; private set
            {
                if (value < 0)
                {
                    throw new UserInputException("Numéro de chambre incorrect");
                }
                _numeroChambre = value;
            }
        }
        public ChambreStatut StatutChambre { get; private set; }
        public int NbLit
        {
            get => _nbLit; private set
            {
                if (value <= 0)
                {
                    throw new UserInputException("Nombre de lit inférieur ou égal à 0");
                }
                _nbLit = value;
            }
        }
        public decimal Tarif
        {
            get => _tarif; private set
            {
                if (value < 0)
                {
                    throw new UserInputException("Tarif inférieur à 0");
                }
            }
        }

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
