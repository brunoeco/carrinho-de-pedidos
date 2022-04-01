using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TesteSQLServer.Database.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Repositories.Interfaces;

namespace TesteSQLServer.Repositories
{
    public class OrdersRepository : IOrdersRepository 
    {
        private IConnection Connection;

        public OrdersRepository(IConnection connection)
        {
            Connection = connection;
        }

        public ReadOrderDto GetOrderById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"SELECT * " +
                    $"FROM orders " +
                    $"INNER JOIN payments ON orders.PaymentId = payments.Id " +
                    $"INNER JOIN addresses ON orders.Id = addresses.OrderId " +
                    $"INNER JOIN orderItems ON orders.Id = orderItems.OrderId " +
                    $"WHERE orders.Id = {id}";

                var order = connection.Query<ReadOrderDto, Payment, Address, OrderItem, ReadOrderDto>
                    (query, (order, payment, address, orderItem) => 
                    {
                        if (order.OrderItems == null)
                        {
                            order.OrderItems = new List<OrderItem>();
                        }

                        order.Payment = payment;
                        order.Address = address;
                        order.OrderItems.Add(orderItem);

                        return order;
                    });

                if (!order.Any())
                {
                    return null;
                }

                return order.First();
            }
        }

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(string userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"SELECT * " +
                    $"FROM orders " +
                    $"INNER JOIN payments ON orders.PaymentId = payments.Id " +
                    $"INNER JOIN addresses ON orders.Id = addresses.OrderId " +
                    $"INNER JOIN orderItems ON orders.Id = orderItems.OrderId " +
                    $"WHERE UserId = {userId}";

                var orders = new Dictionary<int, ReadOrderDto>();

                connection.Query<ReadOrderDto, Payment, Address, OrderItem, ReadOrderDto>
                    (query, (order, payment, address, orderItem) => {
                        ReadOrderDto tempOrder;

                        if (!orders.TryGetValue(order.Id, out tempOrder))
                        {
                            orders.Add(order.Id, tempOrder = order);
                        }

                        if (tempOrder.OrderItems == null)
                        {
                            tempOrder.OrderItems = new List<OrderItem>();
                        }

                        tempOrder.Payment = payment;
                        tempOrder.Address = address;
                        tempOrder.OrderItems.Add(orderItem);

                        return tempOrder;
                    });

                return orders.Values.ToList();
            }
        }

        public int CreateOrder(CreateOrderDto createOrderDto, string userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"INSERT INTO orders (UserId, PaymentId, CreatedAt) " +
                    $"VALUES ({userId}, {createOrderDto.PaymentId}, '{DateTime.Now.Date.ToString("dd/MM/yyyy")}') " +
                    $"SELECT SCOPE_IDENTITY()";

                var orderId = connection.QueryFirst<int>(query);

                query = $"INSERT INTO addresses (Street, District, City, State, ZipCode, OrderId) " +
                    $"VALUES ('{createOrderDto.Address.Street}', '{createOrderDto.Address.District}', " +
                    $"'{createOrderDto.Address.City}', '{createOrderDto.Address.State}', " +
                    $"'{createOrderDto.Address.ZipCode}', '{orderId}')";

                connection.Query(query);

                var itemsValues = String.Join(",", createOrderDto.OrderItems.Select(item => $"(" +
                    $"(SELECT Price FROM products WHERE Id = {item.ProductId})," +
                    $"{item.Quantity}, {item.ProductId}, {orderId}" +
                    $")"));

                query = $"INSERT INTO orderItems (Price, Quantity, ProductId, OrderId) " +
                    $"VALUES {itemsValues}";

                connection.Query(query);

                return orderId;
            }
        }
    }
}
