using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHotel.Models
{
    internal class Client
    {
        [Key]
        [Column("client_id")]
        public int Id { get; set; }
        [Column("nom")]
        [Required]
        public string? Nom { get; set; }
        [Column("prenom")]
        [Required]
        public string? Prenom { get; set; }
        [Column("telephone")]
        [Required]
        public string? Telephone { get; set; }

        public List<Reservation> Reservartions { get; set; } = new List<Reservation>();

        public override string ToString()
        {
            return $"{Id} : Client {Prenom} {Nom}, {Telephone}";
        }
    }
}
