using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Interfaces 
{
    public interface IProductsRepository 
    {
        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto);
    }
}
