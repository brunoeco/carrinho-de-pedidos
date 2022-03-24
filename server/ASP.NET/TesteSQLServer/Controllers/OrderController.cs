using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using Dapper;
using TesteSQLServer.Models;
using System.Transactions;
using TesteSQLServer.Services;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private OrderService _orderService;

        public OrderController(OrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<ReadOrderDto> Show([FromRoute] int id) {
            var order = _orderService.Show(id);

            if (order != null) return Ok(order);

            return NoContent();            
        }

        [HttpGet]
        public ActionResult<List<ReadOrderDto>> Index([FromQuery] int userId) {
            var orders = _orderService.Index(userId);

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] CreateOrderDto createOrderDto) {
            var orderId = _orderService.Create(createOrderDto);

            return Ok(orderId);
        }
    }
}
