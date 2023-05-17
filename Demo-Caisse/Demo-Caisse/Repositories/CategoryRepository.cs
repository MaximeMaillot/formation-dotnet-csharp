using Demo_Caisse.Models;
using Demo_Caisse.Data;
using EFHelper.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Demo_Caisse.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public override List<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            return GetDbSet().Include(c => c.Products).Where(predicate).ToList();
        }

        public override Category? Get(Expression<Func<Category, bool>> predicate)
        {
            return GetDbSet().Include(c => c.Products).FirstOrDefault(predicate);
        }

        public override Category? Find(int id)
        {
            return GetDbSet().Include(c => c.Products).FirstOrDefault(c => c.Id == id);
        }
    }
}
