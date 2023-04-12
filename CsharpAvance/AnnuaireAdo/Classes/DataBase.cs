using Microsoft.Data.SqlClient;

namespace DemoAdo.Classes
{
    internal static class DataBase
    {
        private static SqlConnection _connection = new SqlConnection("Data Source=(localdb)\\cours-dotnet;Integrated Security=True");
        public static SqlConnection Connection
        {
            get => _connection;
        }
    }
}
