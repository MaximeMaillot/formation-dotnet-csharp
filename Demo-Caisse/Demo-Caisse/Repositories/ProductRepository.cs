using Demo_Caisse.Models;
using Demo_Caisse.Data;
using EFHelper.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Demo_Caisse.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context) {
        }

        public override List<Product> GetAll()
        {
            return GetDbSet().Include(p => p.Category).ToList();
        }
        public override Product? Find(int id)
        {
            return GetDbSet().Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }
}
