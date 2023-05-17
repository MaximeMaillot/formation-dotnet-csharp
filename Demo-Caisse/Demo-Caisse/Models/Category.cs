using System.ComponentModel.DataAnnotations;

namespace Demo_Caisse.Models
{
    public class Category
    {
        [Display(Name = "ID")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        public string? Name { get; set; }
        [Display(Name = "Liste de produits")]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
