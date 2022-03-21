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

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase {
        private IConfiguration _configuration;
        private string _connectionString;

        public OrdersController(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadOrderDto[]>> Index([FromRoute] int id) {

            string query = $"SELECT * " +
                $"FROM orders " +
                $"INNER JOIN payments ON orders.PaymentId = payments.Id " +
                $"INNER JOIN addresses ON orders.Id = addresses.OrderId " +
                $"INNER JOIN orderItems ON orders.Id = orderItems.OrderId " +
                $"WHERE UserId = {id}";

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var orders = new Dictionary<int, ReadOrderDto>();
                    
                await connection.QueryAsync<ReadOrderDto, Payment, Address, OrderItem, ReadOrderDto>
                    (query, (order, payment, address, orderItem) => {
                        ReadOrderDto tempOrder;

                        if(!orders.TryGetValue(order.Id, out tempOrder)) {
                            orders.Add(order.Id, tempOrder = order);
                        }

                        if (tempOrder.OrderItems == null) {
                            tempOrder.OrderItems = new List<OrderItem>();
                        }

                        tempOrder.Payment = payment;
                        tempOrder.Address = address;
                        tempOrder.OrderItems.Add(orderItem);

                        return tempOrder;
                    });

                return Ok(orders.Values.ToList());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderDto createOrderDto) {

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                        string query = $"INSERT INTO orders (UserId, PaymentId, CreatedAt) " +
                            $"VALUES ({createOrderDto.UserId}, {createOrderDto.PaymentId}, '{DateTime.Now.Date.ToString("dd/MM/yyyy")}') " +
                            $"SELECT SCOPE_IDENTITY()";

                        var orderId = await connection.QueryFirstAsync<int>(query);

                        query = $"INSERT INTO addresses (Street, District, City, State, ZipCode, OrderId) " +
                            $"VALUES ('{createOrderDto.Address.Street}', '{createOrderDto.Address.District}', " +
                            $"'{createOrderDto.Address.City}', '{createOrderDto.Address.State}', " +
                            $"'{createOrderDto.Address.ZipCode}', '{orderId}')";

                        await connection.QueryAsync(query);

                        var itemsValues = String.Join(",", createOrderDto.OrderItems.Select(item => $"(" +
                            $"(SELECT Price FROM products WHERE Id = {item.ProductId})," +
                            $"{item.Quantity}, {item.ProductId}, {orderId}" +
                            $")"));

                        query = $"INSERT INTO orderItems (Price, Quantity, ProductId, OrderId) " +
                            $"VALUES {itemsValues}";

                        await connection.QueryAsync(query);

                        return NoContent();
            }
        }
    }
}
