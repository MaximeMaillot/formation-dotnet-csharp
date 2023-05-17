using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo_Caisse.Models
{
    public class Product
    {
        [Display(Name = "ID")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Manquante")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La description doit être compris entre 5 et 50 caractères.")]
        public string? Description { get; set; }
        [Display(Name = "Prix")]
        [Precision(18, 2)]
        [Required(ErrorMessage = "Format du prix incorrect")]
        public decimal Price { get; set; }
        [Display(Name = "Quantité en stock")]
        [Required(ErrorMessage = "Quantité Manquante")]
        public int Quantity { get; set; }
        [Display(Name = "Catégorie ID")]
        [Required(ErrorMessage = "Catégorie Manquante")]
        public int CategoryId { get; set; }
        [Display(Name = "Catégorie")]
        public Category? Category { get; set; }
        [Display(Name = "Image du produit")]
        public string? ProductUrl { get; set; }
    }
}
