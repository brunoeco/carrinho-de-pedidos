using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Products;

namespace TesteSQLServer.Services.Products
{
    public class ProductsService : IProductsService 
    {
        private readonly IProductsRepository ProductsRepository;

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
