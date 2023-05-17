using System.Linq.Expressions;

namespace WebApplication1.Interfaces
{
    public interface IRepository<TEntity>
    {
        //CREATE
        bool Add(TEntity entity);
        // READ
        TEntity? Find(params object[] id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        // UPDATE
        bool Update(TEntity entity);
        // DELETE
        bool Remove(params object[] id);
    }
}
