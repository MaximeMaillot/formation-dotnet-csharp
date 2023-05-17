using System.ComponentModel.DataAnnotations;

namespace demo_contact.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName => FirstName + " " + LastName;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age =>
            DateTime.Now.Month < BirthDate.Month
            ? DateTime.Now.Year - BirthDate.Year - 1 // Birthmonth is later in the year
            : DateTime.Now.Month == BirthDate.Month
                ? DateTime.Now.Day < BirthDate.Day // Same Month, so we check the day
                    ? DateTime.Now.Year - BirthDate.Year - 1 
                    : DateTime.Now.Year - BirthDate.Year
                : DateTime.Now.Year - BirthDate.Year; // Birthmonth is sooner in the year
        [Required]
        public string Sexe { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
