using Microsoft.EntityFrameworkCore;
using Demo_Caisse.Models;

namespace Demo_Caisse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Produits { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();
            var categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Produits ménagers" },
                new Category { Id = 2, Name = "Accessoires g@m3r" },
            };
            modelBuilder.Entity<Category>().HasData(categories);
            var produits = new List<Product>()
            {
                new Product { Id = 1, Name = "Toudoux", CategoryId = 1, Description = "Le meilleur de tous les produits ménagers", ProductUrl = "test", Price = 6.49m, Quantity = 10},
                new Product { Id = 2, Name = "Calgon", CategoryId = 1, Description = "Le calcaire c'est la mort", ProductUrl = "test", Price = 12.49m, Quantity = 20},
                new Product { Id = 3, Name = "Razer", CategoryId = 2, Description = "Une souris", ProductUrl = "test", Price = 62.22m, Quantity = 5},
                new Product { Id = 4, Name = "Logitech", CategoryId = 2, Description = "Un clavier", ProductUrl = "test", Price = 148.0m, Quantity = 3},
            };
            modelBuilder.Entity<Product>().HasData(produits);
        }
    }
}
