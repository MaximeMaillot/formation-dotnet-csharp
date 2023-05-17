using System.ComponentModel.DataAnnotations;

namespace demo_api.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sexe { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
