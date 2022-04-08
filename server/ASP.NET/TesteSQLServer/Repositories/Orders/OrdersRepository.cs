using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Repositories.Orders
{
    public class OrdersRepository : IOrdersRepository 
    {
        private readonly IConnection Connection;

        public OrdersRepository(IConnection connection)
        {
            Connection = connection;
        }

        public ReadOrderDto GetOrderById(string id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"SELECT o.id, o.[user-id] AS userId, o.[created-at] AS createdAt, o.[payment-id] AS paymentId, " +
                    $"py.*, ad.*,  " +
                    $"oi.*, oi.[product-id] AS productId  " +
                    $"FROM orders o " +
                    $"INNER JOIN payments py ON o.[payment-id] = py.id " +
                    $"INNER JOIN addresses ad ON o.id = ad.[order-id] " +
                    $"INNER JOIN [order-items] oi ON o.id = oi.[order-id] " +
                    $"WHERE o.id = @Id";

                var dictionary = new Dictionary<string, object>
                {
                    {"@Id", id }
                };

                var parameters = new DynamicParameters(dictionary);

                var orders = new Dictionary<Guid, ReadOrderDto>();

                connection.Query<ReadOrderDto, ReadPaymentDto, ReadAddressDto, ReadOrderItemDto, ReadOrderDto>
                    (query, (order, payment, address, orderItem) => 
                    {
                        if (!orders.TryGetValue(order.Id, out ReadOrderDto tempOrder))
                        {
                            orders.Add(order.Id, tempOrder = order);
                        }

                        if (tempOrder.OrderItems == null)
                        {
                            tempOrder.OrderItems = new List<ReadOrderItemDto>();
                        }

                        tempOrder.Payment = payment;
                        tempOrder.Address = address;
                        tempOrder.OrderItems.Add(orderItem);

                        return tempOrder;
                    }, parameters);

                if (!orders.Any())
                {
                    return null;
                }

                return orders.Values.ToList().First();
            }
        }

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(string userId)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string query = $"SELECT o.id, o.[user-id] AS userId, o.[created-at] AS createdAt, o.[payment-id] AS paymentId, " +
                $"py.*, ad.*,  " +
                $"oi.*, oi.[product-id] AS productId  " +
                $"FROM orders o " +
                $"INNER JOIN payments py ON o.[payment-id] = py.id " +
                $"INNER JOIN addresses ad ON o.id = ad.[order-id] " +
                $"INNER JOIN [order-items] oi ON o.id = oi.[order-id] " +
                $"WHERE o.[user-id] = @UserId";

            var dictionary = new Dictionary<string, object>
            {
                {"@UserId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            var orders = new Dictionary<Guid, ReadOrderDto>();

            connection.Query<ReadOrderDto, ReadPaymentDto, ReadAddressDto, ReadOrderItemDto, ReadOrderDto>
                (query, (order, payment, address, orderItem) =>
                {
                    if (!orders.TryGetValue(order.Id, out ReadOrderDto tempOrder))
                    {
                        orders.Add(order.Id, tempOrder = order);
                    }

                    if (tempOrder.OrderItems == null)
                    {
                        tempOrder.OrderItems = new List<ReadOrderItemDto>();
                    }

                    tempOrder.Payment = payment;
                    tempOrder.Address = address;
                    tempOrder.OrderItems.Add(orderItem);

                    return tempOrder;
                }, parameters);

            return orders.Values.ToList();
        }

        public string CreateOrder(CreateOrderDto createOrderDto, string userId)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();
            using var tran = connection.BeginTransaction();            

            try
            {
                var orderQuery = $"INSERT INTO orders (id, [User-Id], [Payment-Id], [Created-At]) " +
                    $"VALUES (@OrderId, @UserId, @PaymentId, @CreatedAt) ";

                var addressQuery = $"INSERT INTO addresses (Id, Street, District, City, State, ZipCode, [Order-Id]) " +
                    $"VALUES (@AddressId, @Street, @District, " +
                    $"@City, @State, " +
                    $"@ZipCode, @OrderId)";

                var itemsValues = String.Join(",", createOrderDto.OrderItems.Select((item, index) => $"(" +
                    $"@ItemId_{index}, (SELECT Price FROM products WHERE Id = @ProductId_{index})," +
                    $"@Quantity_{index}, @ProductId_{index}, @OrderId" +
                    $")"));

                var orderItemsQuery = $"INSERT INTO [order-items] (Id, Price, Quantity, [Product-Id], [Order-Id]) " +
                    $"VALUES {itemsValues}";

                var dictionary = new Dictionary<string, object>
                        {
                            {"@OrderId", Guid.NewGuid() },
                            {"@UserId", userId },
                            {"@PaymentId", createOrderDto.PaymentId },
                            {"@CreatedAt", DateTime.Now.Date.ToString("dd/MM/yyyy") },
                            {"@AddressId", Guid.NewGuid() },
                            {"@Street", createOrderDto.Address.Street },
                            {"@District", createOrderDto.Address.District },
                            {"@City", createOrderDto.Address.City },
                            {"@State", createOrderDto.Address.State },
                            {"@ZipCode", createOrderDto.Address.ZipCode },
                        };

                foreach (var item in createOrderDto.OrderItems.Select((value, index) => new { index, value }))
                {
                    dictionary.Add($"@ItemId_{item.index}", Guid.NewGuid());
                    dictionary.Add($"@ProductId_{item.index}", item.value.ProductId);
                    dictionary.Add($"@Quantity_{item.index}", item.value.Quantity);
                }

                var parameters = new DynamicParameters(dictionary);

                var orderId = dictionary["@OrderId"];

                connection.Execute(orderQuery, parameters, tran);

                connection.Execute(addressQuery, parameters, tran);

                connection.Execute(orderItemsQuery, parameters, tran);

                tran.Commit();

                return orderId.ToString();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
