using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace demo_pizzeria.Models
{
    public class Pizza
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
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

    public enum PizzaType
    {
        Vegetarienne,
        Piquante
    }
}
