using AdoBank.Classes.Ado.Filters;
using DemoAdo.Classes;
using Helper.Classes;
using Microsoft.Data.SqlClient;

namespace CompteBancaire.Classes.Comptes
{
    internal abstract class BankAccount
    {
        public int Id { get; private set; }
        public decimal Solde { get; set; } = 0;
        public Client Client { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        public static SqlConnection connection = DataBase.Connection;
        public static SqlCommand command;
        public static SqlDataReader reader;

        public BankAccount(Client client)
        {
            Client = client;
        }

        public BankAccount(int id, decimal solde, Client client)
        {
            Id = id;
            Solde = solde;
            Client = client;
        }

        public override string ToString()
        {
            return $"numéro {Id} pour {Client.FirstName} {Client.LastName} à un solde de {Solde} euros";
        }

        public static bool Deposit(int id, decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Dépôt d'une valeur négative impossible");
            }

            connection.Open();
            string request = "UPDATE bankaccount SET solde = solde + @solde WHERE bankaccount_id = @id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", amount));
            command.Parameters.Add(new SqlParameter("@id", id));
            int nb = command.ExecuteNonQuery();
            if (nb <= 0)
            {
                throw new Exception("Update de bankaccount a échoué");
            }
            command.Dispose();
            connection.Close();

            int operation_id = Operation.CreateOperation(new Operation(amount, OperationStatus.Deposit));

            connection.Open();
            request = "INSERT INTO bankaccount_operation VALUES (@bankaccount_id, @operation_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@bankaccount_id", id));
            command.Parameters.Add(new SqlParameter("@operation_id", operation_id));
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb > 0;
        }

        public static bool Withdrawal(int id, decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Retrait d'une valeur négative impossible");
            }
            // Get the current solde
            connection.Open();
            string select = "SELECT solde FROM bankaccount WHERE bankaccount_id = @id";
            command = new SqlCommand(select, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            decimal solde = (decimal)command.ExecuteScalar();
            if (solde < amount)
            {
                throw new Exception("Solde insuffisant");
            }
            command.Dispose();
            connection.Close();

            // Update the solde
            connection.Open();
            string update = "UPDATE bankaccount SET solde = solde - @solde WHERE bankaccount_id = @id";
            command = new SqlCommand(update, connection);
            command.Parameters.Add(new SqlParameter("@solde", amount));
            command.Parameters.Add(new SqlParameter("@id", id));
            int nb = command.ExecuteNonQuery();
            if (nb <= 0)
            {
                throw new Exception("Update de bankaccount a échoué");
            }
            command.Dispose();
            connection.Close();

            // Add the operation
            int operation_id = Operation.CreateOperation(new Operation(amount, OperationStatus.Deposit));

            // Add the link between the operation and the bankaccount
            connection.Open();
            string insert = "INSERT INTO bankaccount_operation VALUES (@bankaccount_id, @operation_id)";
            command = new SqlCommand(insert, connection);
            command.Parameters.Add(new SqlParameter("@bankaccount_id", id));
            command.Parameters.Add(new SqlParameter("@operation_id", operation_id));
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb > 0;
        }

        public static List<BankAccount> GetBankAccounts()
        {
            List<BankAccount> bankAccounts = new();

            connection.Open();
            string selectBankAccount = "SELECT bankaccount_id, solde, client_id FROM bankaccount";
            command = new SqlCommand(selectBankAccount, connection);
            reader = command.ExecuteReader();
            List<(int bankaccount_id, decimal solde, int client_id)> bankAccountsResults = new();
            while (reader.Read())
            {
                bankAccountsResults.Add((reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2)));
            }
            reader.Close();
            command.Dispose();

            
            bankAccountsResults.ForEach((bankaccount) =>
            {
                string selectClient = "SELECT client_id, firstname, lastname, phone WHERE client_id = @client_id";
                command = new SqlCommand(selectClient, connection);
                command.Parameters.Add(new SqlParameter("@client_id", bankaccount.client_id));
                reader = command.ExecuteReader();
                reader.Read();
                bankAccounts.Add(new CurrentAccount(bankaccount.bankaccount_id, bankaccount.solde, new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3))));
                reader.Close();
                command.Dispose();
            });
            

            return bankAccounts;
        }
    }
}
