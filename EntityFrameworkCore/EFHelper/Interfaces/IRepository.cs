using System.Linq.Expressions;

namespace EFHelper.Interfaces
{
    public interface IRepository<TEntity>
    {
        //CREATE
        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);
        // READ
        TEntity? Find(params object[] id);
        Task<TEntity?> FindAsync(params object[] id);
        TEntity? Find(int id);
        Task<TEntity?> FindAsync(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        // UPDATE
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        // DELETE
        bool Remove(params object[] id);
        bool Remove(int id);
        bool Remove(TEntity entity);
    }
}
