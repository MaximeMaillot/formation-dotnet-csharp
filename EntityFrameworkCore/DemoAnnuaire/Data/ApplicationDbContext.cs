using DemoAnnuaire.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAnnuaire.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }

        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\annuaire;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>().HasData(new Adresse()
            {
                Id = 1,
                NumeroVoie = "1",
                IntituleVoie = "rue avenue",
                ComplementAdresse = "Complement",
                Commune = "Ville",
                CodePostal = "012345"
            });
        }
    }
}
