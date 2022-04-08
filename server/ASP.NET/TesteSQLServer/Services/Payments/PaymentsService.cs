using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Payments;

namespace TesteSQLServer.Services.Payments
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository PaymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            PaymentsRepository = paymentsRepository;
        }
        public IEnumerable<ReadPaymentDto> GetAllPayments()
        {
            var payments = PaymentsRepository.GetAllPayments();

            return payments;
        }
    }
}
