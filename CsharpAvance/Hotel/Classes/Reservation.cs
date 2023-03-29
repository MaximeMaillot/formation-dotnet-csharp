using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes
{
    internal class Reservation
    {
        public Reservation(string statut, List<Chambre> chambres, Client client) {
            Numero++;
            Statut = statut;
            Chambres = chambres;
            Client = client;
        }
        public Reservation(string statut, Chambre chambre, Client client)
        {
            Numero++;
            Statut = statut;
            Chambres.Add(chambre);
            Client = client;
        }
        public static int Numero { get; set; }
        public string Statut { get; set; }
        public List<Chambre> Chambres { get; set; }
        public Client Client { get; set; }
    }
}
