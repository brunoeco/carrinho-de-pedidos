using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Services
{
    public class OrdersService : IOrdersService 
    {
        private IOrdersRepository OrdersRepository;
        private ITokenService TokenService;

        public OrdersService(IOrdersRepository ordersRepository, ITokenService tokenService) 
        {
            OrdersRepository = ordersRepository;
            TokenService = tokenService;
        }

        public ReadOrderDto GetOrderById(int id) 
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

        public int CreateOrder(CreateOrderDto createOrderDto, HttpContext context)
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var orderId = OrdersRepository.CreateOrder(createOrderDto, userId);

            return orderId;
        }
    }
}
