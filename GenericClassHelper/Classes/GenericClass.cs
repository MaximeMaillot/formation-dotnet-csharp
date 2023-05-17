namespace GenericClassHelper.Classes
{
    public class GenericClass<TEntity>
    {
        public static object GetValue(TEntity item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null);
        }

        public static void SetValue(TEntity item, string propertyName, object value)
        {
            item.GetType().GetProperty(propertyName).SetValue(item, value, null);
        }
    }
}
