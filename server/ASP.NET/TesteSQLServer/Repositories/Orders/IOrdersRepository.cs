using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Orders
{
    public interface IOrdersRepository 
    {
        public ReadOrderDto GetOrderById(string id);

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(string userId);

        public string CreateOrder(CreateOrderDto createOrderDto, string userId);
    }
}
