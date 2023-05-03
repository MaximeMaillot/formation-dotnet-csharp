using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\efcore;Integrated Security=True");
        }
    }
}
