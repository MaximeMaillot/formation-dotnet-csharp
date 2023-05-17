using EFHelper.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using GenericClassHelper.Classes;

namespace EFHelper.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /* ---  Helper Functions  --- */

        protected DbSet<TEntity> GetDbSet()
        {
            return _dbContext.Set<TEntity>();
        }

        public List<string> GetPrimaryKeyAttributeNames()
        {
            var keyNames = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name).ToList();
            if (keyNames.Count > 0)
            {
                return keyNames;
            }
            throw new Exception("No primary key in the table");
        }

        /* ---  DB Functions  --- */

        // READ
        public virtual TEntity? Find(params object[] id)
        {
            return GetDbSet().Find(id);
        }

        public virtual async Task<TEntity?> FindAsync(params object[] id)
        {
            return await GetDbSet().FindAsync(id); ;
        }

        public virtual TEntity? Find(int id)
        {
            return GetDbSet().Find(id);
        } 

        public virtual async Task<TEntity?> FindAsync(int id)
        {
            return await GetDbSet().FindAsync(id); ;
        }

        public virtual TEntity? FirstOrDefault()
        {
            return GetDbSet().FirstOrDefault();
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync()
        {
            return await GetDbSet().FirstOrDefaultAsync();
        }

        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetDbSet().FirstOrDefaultAsync(predicate);
        }

        public virtual List<TEntity> GetAll()
        {
            return GetDbSet().ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return GetDbSet().ToListAsync();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return GetDbSet().Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetDbSet().Where(predicate).ToListAsync();
        }

        // CREATE

        public virtual int Add(TEntity item)
        {
            List<string> keyNames = GetPrimaryKeyAttributeNames();
            var addedObj = GetDbSet().Add(item);
            _dbContext.SaveChanges();
            return (int)GenericClass<TEntity>.GetValue(addedObj.Entity, keyNames[0]);
        }

        public virtual async Task<int> AddAsync(TEntity item)
        {
            List<string> keyNames = GetPrimaryKeyAttributeNames();
            var addedObj = await GetDbSet().AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return (int)GenericClass<TEntity>.GetValue(addedObj.Entity, keyNames[0]);
        }

        public virtual List<int> AddMultipleKeys(TEntity item)
        {
            List<string> keyNames = GetPrimaryKeyAttributeNames();
            var addedObj = GetDbSet().Add(item);
            _dbContext.SaveChanges();
            List<int> keys = new List<int>();
            foreach (var name in keyNames)
            {
                keys.Add((int)GenericClass<TEntity>.GetValue(addedObj.Entity, name));
            }
            return keys;
        }

        public virtual async Task<List<int>> AddMultipleKeysAsync(TEntity item)
        {
            List<string> keyNames = GetPrimaryKeyAttributeNames();
            var addedObj = await GetDbSet().AddAsync(item);
            await _dbContext.SaveChangesAsync();
            List<int> keys = new List<int>();
            foreach (var name in keyNames)
            {
                keys.Add((int)GenericClass<TEntity>.GetValue(addedObj.Entity, name));
            }
            return keys;
        }

        // UPDATE

        public virtual bool Update(TEntity newItem)
        {
            List<string> primaryKeyNames = GetPrimaryKeyAttributeNames();
            List<object> idList = new();
            foreach (var key in primaryKeyNames)
            {
                idList.Add(GenericClass<TEntity>.GetValue(newItem, key));
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
                    GenericClass<TEntity>.SetValue(item, property.Name, GenericClass<TEntity>.GetValue(newItem, property.Name));
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity newItem)
        {
            List<string> primaryKeyNames = GetPrimaryKeyAttributeNames();
            List<object> idList = new();
            foreach (var key in primaryKeyNames)
            {
                idList.Add(GenericClass<TEntity>.GetValue(newItem, key));
            }
            TEntity? item = await FindAsync(idList.ToArray());
            if (item == null)
            {
                return false;
            }

            var properties = newItem.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (!primaryKeyNames.Contains(property.Name))
                {
                    GenericClass<TEntity>.SetValue(item, property.Name, GenericClass<TEntity>.GetValue(newItem, property.Name));
                }
            }
            return await _dbContext.SaveChangesAsync() > 0;
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

        public virtual bool Remove(int id)
        {
            TEntity item = Find(id);
            if (item == null)
            {
                return false;
            }
            GetDbSet().Remove(item);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool Remove(TEntity entity)
        {
            GetDbSet().Remove(entity); 
            return _dbContext.SaveChanges() > 0;
        }
    }
}
