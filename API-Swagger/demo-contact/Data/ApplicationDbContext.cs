using demo_contact.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_contact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contacts = new List<Contact>() {
                new Contact()
                {
                    FirstName = "Maxime",
                    LastName = "Maillot",
                    Id = 1,
                    Sexe = "Male",
                    AvatarUrl = null,
                    BirthDate = DateTime.ParseExact("1993-11-04", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Contact()
                {
                    FirstName = "Martial",
                    LastName = "Maillot",
                    Id = 2,
                    Sexe = "Male",
                    AvatarUrl = null,
                    BirthDate = DateTime.ParseExact("1986-05-05", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Contact()
                {
                    FirstName = "Mathilde",
                    LastName = "Vermuse",
                    Id = 3,
                    Sexe = "Female",
                    AvatarUrl = null,
                    BirthDate = DateTime.ParseExact("1989-10-14", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                }
            };
            modelBuilder.Entity<Contact>().HasData(contacts);
        }
    }
}
