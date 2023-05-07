using DemoHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHotel.Data
{
    internal class HotelDbContext : DbContext
    {
        public HotelDbContext() : base()
        {

        }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<ReservationChambre> ReservationChambres {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\demo-hotel;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationChambre>().HasKey(table => new
            {
                table.ReservationId, table.ChambreId
            });
            modelBuilder.Entity<Chambre>().HasData(new Chambre()
            {
                Id = 1,
                NbLit = 2,
                Tarif = 32.25m
            }, new Chambre()
            {
                Id = 2,
                NbLit = 4,
                Tarif = 62.25m
            }, new Chambre()
            {
                Id = 3,
                NbLit = 6,
                Tarif = 82.25m
            }, new Chambre()
            {
                Id = 4,
                NbLit = 3,
                Tarif = 52.25m
            }
            );
        }
    }
}
