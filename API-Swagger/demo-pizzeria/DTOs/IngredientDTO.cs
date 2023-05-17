using demo_pizzeria.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo_pizzeria.DTOs
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public int PizzaId { get; set; }
    }
}
