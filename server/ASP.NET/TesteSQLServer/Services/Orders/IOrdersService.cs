using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Orders
{
    public interface IOrdersService 
    {
        public ReadOrderDto GetOrderById(string id);

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(HttpContext context);

        public string CreateOrder(CreateOrderDto createOrderDto, HttpContext context);
    }
}

