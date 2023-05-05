using DemoContact.Models;
using Microsoft.EntityFrameworkCore;


namespace DemoContact.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base()
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\demo-asp-contact;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact() {Id= 1, LastName = "Maxime", FirstName = "Maillot" }, new Contact() { Id = 2, LastName = "Gianni", FirstName = "Mondello"});
        }

    }
}
