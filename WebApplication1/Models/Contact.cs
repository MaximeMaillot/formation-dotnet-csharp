using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "Prénom")]
        public string? FirstName { get; set; }
        [Display(Name = "Nom")]
        public string? LastName { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Téléphone")] // le display par défaut correspond au nom de pla propriété (== nameof(Phone))
        public string? Phone { get; set; }

    }
}
