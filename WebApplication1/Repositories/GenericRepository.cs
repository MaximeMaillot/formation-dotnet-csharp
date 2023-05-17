using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _dbContext { get; }
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /* ---  Helper Functions  --- */

        protected DbSet<TEntity> GetDbSet()
        {
            return _dbContext.Set<TEntity>();
        }

        protected List<string> GetPrimaryKeyAttributeNames()
        {
            var keyNames = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name).ToList();
            if (keyNames.Count > 0)
            {
                return keyNames;
            }
            throw new Exception("No primary key in the table");
        }

        protected object GetValue(TEntity item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null);
        }

        protected void SetValue(TEntity item, string propertyName, object value)
        {
            item.GetType().GetProperty(propertyName).SetValue(item, value, null);
        }

        /* ---  DB Functions  --- */

        // READ

        public virtual TEntity? Find(params object[] id)
        {
            return GetDbSet().Find(id);
        }

        public virtual TEntity? FirstOrDefault()
        {
            return GetDbSet().FirstOrDefault();
        }

        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().FirstOrDefault(predicate);
        }

        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            DbSet<TEntity> dbSet = GetDbSet();

            IIncludableQueryable<TEntity, object>? includeQuery = dbSet.Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
            {
                includeQuery = includeQuery.Include(includes[i]);
            }

            return includeQuery.FirstOrDefault(predicate);
        }

        public virtual TEntity? Get(IIncludableQueryable<TEntity, object> includeQuery, Expression<Func<TEntity, bool>> predicate)
        {
            return includeQuery.FirstOrDefault(predicate);
        }

        public virtual List<TEntity> GetAll()
        {
            return GetDbSet().ToList();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().Where(predicate).ToList();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include)
        {

            return GetDbSet().Include(include).Where(predicate).ToList() ;
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = GetDbSet();
            IIncludableQueryable<TEntity, object>? includeQuery = dbSet.Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
            {
                includeQuery = includeQuery.Include(includes[i]);
            }
            return dbSet.Where(predicate).ToList();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, object>> include)
        {

            return GetDbSet().Include(include).ToList();
        }

        public virtual List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = GetDbSet();
            IIncludableQueryable<TEntity, object>? includeQuery = dbSet.Include(includes[0]);

            for (int i = 1; i < includes.Length; i++)
            {
                includeQuery = includeQuery.Include(includes[i]);
            }
            return dbSet.ToList();
        }

        // CREATE

        public virtual bool Add(TEntity item)
        {
            List<string> keyNames = GetPrimaryKeyAttributeNames();
            var addedObj = GetDbSet().Add(item);
            _dbContext.SaveChanges();
            return (int)GetValue(addedObj.Entity, keyNames[0]) > 0;
        }

        // UPDATE

        public virtual bool Update(TEntity newItem)
        {
            List<string> primaryKeyNames = GetPrimaryKeyAttributeNames();
            List<object> idList = new();
            foreach (var key in primaryKeyNames)
            {
                idList.Add(GetValue(newItem, key));
            }
            TEntity? item = Find(idList.ToArray());
            if (item == null)
            {
                return false;
            }

            var properties = newItem.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (!primaryKeyNames.Contains(property.Name))
                {
                    SetValue(item, property.Name, GetValue(newItem, property.Name));
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        // REMOVE

        public virtual bool Remove(params object[] id)
        {
            TEntity item = Find(id);
            if (item == null)
            {
                return false;
            }
            GetDbSet().Remove(item);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
