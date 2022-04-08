using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Orders;
using TesteSQLServer.Services.Utils.Token;

namespace TesteSQLServer.Services.Orders
{
    public class OrdersService : IOrdersService 
    {
        private readonly IOrdersRepository OrdersRepository;
        private readonly ITokenService TokenService;

        public OrdersService(IOrdersRepository ordersRepository, ITokenService tokenService) 
        {
            OrdersRepository = ordersRepository;
            TokenService = tokenService;
        }

        public ReadOrderDto GetOrderById(string id) 
        {
            var order = OrdersRepository.GetOrderById(id);

            return order;
        }

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var orders = OrdersRepository.GetAllOrdersByUserId(userId);

            return orders;
        }

        public string CreateOrder(CreateOrderDto createOrderDto, HttpContext context)
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var orderId = OrdersRepository.CreateOrder(createOrderDto, userId);

            return orderId;
        }
    }
}
