using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Products 
{
    public interface IProductsRepository 
    {
        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto);
    }
}
