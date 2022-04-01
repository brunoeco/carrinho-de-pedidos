using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Services
{
    public class ProductsService : IProductsService 
    {
        private IProductsRepository ProductsRepository;

        public ProductsService(IProductsRepository productsRepository) 
        {
            ProductsRepository = productsRepository;
        }

        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto)
        {
            var products = ProductsRepository.GetAllProducts(filterDto);

            return products;
        }
    }
}
