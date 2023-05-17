using demo_pizzeria.Data;
using demo_pizzeria.Models;
using EFHelper.Repositories;
using Microsoft.EntityFrameworkCore;

namespace demo_pizzeria.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
