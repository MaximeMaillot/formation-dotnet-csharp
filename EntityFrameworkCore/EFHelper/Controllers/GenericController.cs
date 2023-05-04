using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

// TODO : Handle includes
// TODO : Find a better way to find the primary key ?

namespace DemoHotel.Controllers
{
    internal class GenericController<T> where T : class
    {
        private DbContext _dbContext;

        public GenericController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetPrimaryKeyAttributeName(T item)
        {
            var key = item.GetType().GetProperties().FirstOrDefault(p =>
                p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)));
            if (key != null)
            {
                return key.Name;
            }
            throw new Exception("Primary Key Annotation not set");
        }

        public object GetValue(T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null);
        }

        public void SetValue(T item, string propertyName, object value)
        {
            item.GetType().GetProperty(propertyName).SetValue(item, value, null);
        }

        public bool Add(T item)
        {
            string keyName = GetPrimaryKeyAttributeName(item);
            var addedObj = _dbContext.Set<T>().Add(item);
            return (int)GetValue(addedObj.Entity, keyName) > 0;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public T? GetById(int id)
        {
            T item = _dbContext.Set<T>().Find(id);
            return item;
        }

        public T? GetById(string id)
        {
            T item = _dbContext.Set<T>().Find(id);
            return item;
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public bool Update(T newItem)
        {
            string primaryKeyName = GetPrimaryKeyAttributeName(newItem);
            int id = (int)GetValue(newItem, primaryKeyName);
            T? item = GetById(id);
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
            T item = GetById(id);
            if (item == null)
            {
                return false;
            }
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
