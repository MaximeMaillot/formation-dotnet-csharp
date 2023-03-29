using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes
{
    internal class Chambre
    {
        public Chambre(string statut, int nbLit, float tarif)
        {
            Numero++;
            Statut = statut;
            NbLit = nbLit;
            Tarif = tarif;
        }
        public int Numero { get; set; }
        public string Statut { get; set; }
        public int NbLit { get; set; }
        public float Tarif { get; set; }
    }
}
