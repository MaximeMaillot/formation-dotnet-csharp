using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contacts = new List<Contact>()
            {
                new Contact { Id = 1, FirstName = "Bob", LastName="Marley", Email="bobo@ganjamail.com", Phone="0607080910"},
                new Contact { Id = 2, FirstName = "Elvis", LastName="Presley", Email="elvis@rock.com", Phone="0607080911"},
                new Contact { Id = 3, FirstName = "Michael", LastName="Jackson", Email="mj@popking.com", Phone="0607080912"},
            };
            var todos = new List<Todo>()
            {
                new Todo { Id = 1, Title = "Faire", Description="Tu peux le faire", Status=false},
                new Todo { Id = 2, Title = "Finir", Description="Faut y arriver", Status=false},
                new Todo { Id = 3, Title = "Déprimer", Description="L'alcool est la seule solution", Status=true},
            };
            modelBuilder.Entity<Contact>().HasData(contacts);
            modelBuilder.Entity<Todo>().HasData(todos);
        }
    }
}
