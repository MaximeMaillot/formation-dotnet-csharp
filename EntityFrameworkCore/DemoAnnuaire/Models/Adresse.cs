using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAnnuaire.Models
{
    internal class Adresse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("numero_voie")]
        [Required]
        public string? NumeroVoie { get; set; }
        [Column("complement_adresse")]
        public string? ComplementAdresse { get; set; }
        [Column("intitule_voie")]
        public string? IntituleVoie { get; set; }
        [Column("commune")]
        public string? Commune { get; set; }
        [Column("code_postal")]
        public string? CodePostal { get; set; }

        public override string ToString()
        {
            return $"{Id} : {NumeroVoie} {IntituleVoie} ({ComplementAdresse}), {CodePostal} {Commune}";
        }
    }
}
