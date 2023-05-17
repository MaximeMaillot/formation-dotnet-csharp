using System.ComponentModel.DataAnnotations;

namespace demo_pizzeria.DTOs
{
    public class RegisterRequestDTO
    {
        [Required]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "FirstName must start with an uppercase letter !")]
        public string? FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? LastName { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        // validator de mot de passe à ajouter
        public string? Password { get; set; }
    }
}
