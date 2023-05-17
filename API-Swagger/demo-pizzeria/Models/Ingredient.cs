using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo_pizzeria.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
    }
}
