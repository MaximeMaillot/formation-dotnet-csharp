using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Display(Name = "Titre de la tâche")]
        public string? Title { get; set; }
        [Display(Name = "Description de la tâche")]
        public string? Description { get; set; }
        [Display(Name = "Statut")]
        public bool? Status { get; set; } = false;
    }
}
