using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Payments;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService PaymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            PaymentsService = paymentsService;
        }

        [HttpGet]
        public ActionResult<List<ReadPaymentDto>> Index()
        {
            var payments = PaymentsService.GetAllPayments();

            return Ok(payments);
        }
    }
}
