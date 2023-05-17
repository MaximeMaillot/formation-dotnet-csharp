using demo_pizzeria.Data;
using demo_pizzeria.Models;
using EFHelper.Repositories;
using Microsoft.EntityFrameworkCore;

namespace demo_pizzeria.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>
    {
        public PizzaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Pizza?> FindAsync(int id)
        {
            return await GetDbSet().Include(c => c.Ingredients).FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Pizza>> GetAllAsync()
        {
            return await GetDbSet().Include(c => c.Ingredients).ToListAsync();
        }
    }
}
