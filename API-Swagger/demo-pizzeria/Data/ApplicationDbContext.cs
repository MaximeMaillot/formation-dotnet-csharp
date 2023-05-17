using demo_pizzeria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Text;

namespace demo_pizzeria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Ingredients)
                .WithOne(e => e.Pizza)
                .HasForeignKey(e => e.PizzaId)
                .IsRequired();

            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Root",
                    IsAdmin = true,
                    Address = "",
                    Email = "admin@admin.com",
                    PhoneNumber = "1234567890",
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("root" + "clé super secrète"))
                }
            };
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
