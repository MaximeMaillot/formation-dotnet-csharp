using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DemoHotel.Models
{
    internal class Chambre
    {
        [Key]
        [Column("chambre_id")]
        public int Id { get; set; }
        [Column("statut")]
        [Required]
        public ChambreStatut? Statut { get; set; } = ChambreStatut.Libre;
        [Column("nb_lit")]
        [Required]
        public int NbLit { get; set; }
        [Column("tarif", TypeName = "decimal(10,2)")]
        [Required]
        public decimal Tarif { get; set; }

        public List<ReservationChambre> ReservationChambres { get; set; } = new List<ReservationChambre>();

        public override string ToString()
        {
            return $"{Id} : Chambre avec {NbLit} lits qui est {Statut} et coûte {Tarif}";
        }
    }

    public enum ChambreStatut
    {
        Libre,
        Occupe,
        EnNettoyage
    }
}
