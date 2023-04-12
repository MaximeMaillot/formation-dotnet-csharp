using DemoAdo.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Classes
{
    internal class Operation
    {
        private static int _Number { get; set; } = 1;
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public OperationStatus Status { get; set; }

        public static SqlConnection connection = DataBase.Connection;
        public static SqlCommand command;
        public static SqlDataReader reader;

        private Operation() {
            Number = _Number++;
        }
        public Operation(decimal amount, OperationStatus status):this()
        {
            Amount = amount;
            Status = status;
        }

        public override string ToString()
        {
            return $"Operation {Number} : {Status} de {Amount}";
        }

        public static int CreateOperation(Operation operation)
        {
            connection.Open();
            string request = "INSERT INTO operation OUTPUT INSERTED.operation_id VALUES (@amount, @operation_status)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@amount", operation.Amount));
            command.Parameters.Add(new SqlParameter("@operation_status", operation.Status));
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }
    }

    enum OperationStatus
    {
        Deposit = 0,
        Withdrawal = 1
    }
}
