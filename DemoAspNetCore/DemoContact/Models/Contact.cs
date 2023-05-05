using System.ComponentModel.DataAnnotations;

namespace DemoContact.Models
{
    public class Contact
    {
        [Display(Name = "ID")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string FirstName { get; set; }
        [Display(Name = "Prénom")]
        public string LastName { get; set; }
    }
}
