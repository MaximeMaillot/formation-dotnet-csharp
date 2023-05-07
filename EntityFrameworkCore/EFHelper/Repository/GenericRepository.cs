using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

// TODO : Handle includes
// TODO : Find a better way to find the primary key ?

namespace EFHelper.Repository
{
    public class GenericRepository<T> where T : class
    {
        private DbContext _dbContext;

        private List<Type> _systemTypes;
        public List<Type> SystemTypes
        {
            get
            {
                if (_systemTypes == null)
                {
                    _systemTypes = Assembly.GetExecutingAssembly().GetType().Module.Assembly.GetExportedTypes().ToList();
                }
                return _systemTypes;
            }
        }

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Private function to ease data processing
        private string GetPrimaryKeyAttributeName(T item)
        {
            var key = item.GetType().GetProperties().FirstOrDefault(p =>
                p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)));
            if (key != null)
            {
                return key.Name;
            }
            throw new Exception("Primary Key Annotation not set");
        }

        private List<string> GetForeignKeys(T item)
        {
            List<string> keys = new List<string>();
            var key = item.GetType().GetProperties();
            foreach (var k in key)
            {
                if (!SystemTypes.Contains(k.PropertyType) && k.PropertyType.IsClass)
                {
                    keys.Add(k.Name);
                }
            }
            return keys;
        }

        private List<string> GetForeignKeys(PropertyInfo[] key)
        {
            List<string> keys = new List<string>();
            foreach (var k in key)
            {
                if (!SystemTypes.Contains(k.PropertyType) && k.PropertyType.IsClass)
                {
                    keys.Add(k.Name);
                }
            }
            return keys;
        }

        private List<PropertyInfo> GetForeignKeysType(PropertyInfo[] key)
        {
            List<PropertyInfo> keys = new List<PropertyInfo>();
            foreach (var k in key)
            {
                if (!SystemTypes.Contains(k.PropertyType) && k.PropertyType.IsClass)
                {
                    keys.Add(k);
                }
            }
            return keys;
        }

        private object GetValue(T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null);
        }

        private void SetValue(T item, string propertyName, object value)
        {
            item.GetType().GetProperty(propertyName).SetValue(item, value, null);
        }

        
        // ORM Function
        
        public bool Add(T item)
        {
            string keyName = GetPrimaryKeyAttributeName(item);
            var addedObj = _dbContext.Set<T>().Add(item);
            return (int)GetValue(addedObj.Entity, keyName) > 0;
        }

        public T? First()
        {
            return _dbContext.Set<T>().FirstOrDefault();
        }

        public T? Find(params object[] id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public DbSet<T> GetDbSetWithIncludes()
        {
            List<string> foreignKeys = GetForeignKeys(typeof(T).GetProperties());
            var tContext = _dbContext.Set<T>();
            foreach(string keyName in foreignKeys)
            {
                tContext.Include(c => GetValue(c, keyName));
            }
            return tContext;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public bool Update(T newItem)
        {
            string primaryKeyName = GetPrimaryKeyAttributeName(newItem);
            int id = (int)GetValue(newItem, primaryKeyName);
            T? item = Find(id);
            if (item == null)
            {
                return false;
            }

            var properties = newItem.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name != primaryKeyName)
                {
                    // Get the updated value of the item property 
                    var updatedValue = GetValue(newItem, property.Name);

                    // Set the item with the new value
                    SetValue(item, property.Name, updatedValue);
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            T item = Find(id);
            if (item == null)
            {
                return false;
            }
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
