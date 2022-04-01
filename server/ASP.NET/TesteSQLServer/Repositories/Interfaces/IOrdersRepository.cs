using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Interfaces
{
    public interface IOrdersRepository 
    {
        public ReadOrderDto GetOrderById(int id);

        public IEnumerable<ReadOrderDto> GetAllOrdersByUserId(string userId);

        public int CreateOrder(CreateOrderDto createOrderDto, string userId);
    }
}
