using Microsoft.EntityFrameworkCore;
using TodoApplication.Models;

namespace TodoApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 1, Title = "Faire", Description="Tu peux le faire", Status=false},
                new Todo { Id = 2, Title = "Finir", Description="Faut y arriver", Status=false},
                new Todo { Id = 3, Title = "Déprimer", Description="L'alcool est la seule solution", Status=true},
            };
            modelBuilder.Entity<Todo>().HasData(todos);
        }
    }
}
