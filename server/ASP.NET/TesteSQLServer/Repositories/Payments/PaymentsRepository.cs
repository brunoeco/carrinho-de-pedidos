using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Payments
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly IConnection Connection;

        public PaymentsRepository(IConnection connection)
        {
            Connection = connection;
        }
        public IEnumerable<ReadPaymentDto> GetAllPayments()
        {
            using var connection = Connection.GetConnection();

            connection.Open();

            var query = "SELECT * FROM payments";

            var payments = connection.Query<ReadPaymentDto>(query);

            return payments;
        }
    }
}
