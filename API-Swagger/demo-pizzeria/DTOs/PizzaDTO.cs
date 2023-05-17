using demo_pizzeria.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace demo_pizzeria.DTOs
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public PizzaType PizzaType { get; set; }
        public List<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();
    }
}
