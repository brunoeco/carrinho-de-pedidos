using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface IProductsService 
    {
        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto);
    }
}
