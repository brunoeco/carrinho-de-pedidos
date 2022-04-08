using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Payments
{
    public interface IPaymentsRepository
    {
        public IEnumerable<ReadPaymentDto> GetAllPayments();
    }
}
