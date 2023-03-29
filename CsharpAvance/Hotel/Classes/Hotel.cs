using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Classes
{
    internal class Hotel
    {
        public Hotel(string nom)
        {
            Nom = nom;
            Console.WriteLine($"{nom} a été créer avec succès !");
        }
        public string Nom { get; set; }
        public List<Client> Clients { get; }
        public List<Reservation> Reservations { get; }
        public List<Chambre> Chambres { get; }
    }
}
