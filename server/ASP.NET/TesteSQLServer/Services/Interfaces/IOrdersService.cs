using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface IOrdersService 
    {
        public ReadOrderDto GetOrderById(int id);

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(HttpContext context);

        public int CreateOrder(CreateOrderDto createOrderDto, HttpContext context);
    }
}

