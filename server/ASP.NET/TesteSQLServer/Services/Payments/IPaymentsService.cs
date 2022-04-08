using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Payments
{
    public interface IPaymentsService
    {
        public IEnumerable<ReadPaymentDto> GetAllPayments();
    }
}
