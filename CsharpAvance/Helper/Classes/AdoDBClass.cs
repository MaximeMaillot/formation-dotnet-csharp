using System.Reflection;
using Microsoft.Data.SqlClient;

namespace Helper.Classes
{
    public class AdoDBClass
    {
        public static SqlConnection connection;
        public static SqlCommand command;
        public static SqlDataReader reader; 
        public virtual object this[string name]
        {
            get
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(name);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(name);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}
