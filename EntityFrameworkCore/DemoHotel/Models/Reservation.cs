using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHotel.Models
{
    internal class Reservation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        public ReservationStatut statut { get; set; } = ReservationStatut.Prevu;
        [Column("client_id")]
        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();

        public override string ToString()
        {
            string reservation = $"{Id} : Reservation {statut} | {Client} | \n";
            foreach (var chambre in Chambres)
            {
                reservation += $"\t {chambre.ToString()} \n" ;
            }
            return reservation;
        }
    }

    public enum ReservationStatut
    {
        Prevu,
        EnCours,
        Fini,
        Annule
    }
}
