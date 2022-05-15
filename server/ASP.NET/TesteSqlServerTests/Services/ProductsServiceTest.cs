using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Repositories.Products;
using TesteSQLServer.Services.Products;
using TesteSqlServerTests.Services.FakeRepositories;
using Xunit;

namespace TesteSqlServerTests.Services
{
    public class ProductsServiceTest
    {
        IProductsRepository Repository;
        ProductsService Service;

        public ProductsServiceTest()
        {
            Repository = new ProductsRepositoryFake();
            Service = new ProductsService(Repository);
        }

        [Fact]
        public void WhenCalled_ReturnsListOfThreeProducts()
        {
            var filter = new FilterDto() { };
            var products = Service.GetAllProducts(filter);

            Assert.IsType<List<ReadProductDto>>(products);
            Assert.Equal(3, products.Count());
        }
    }
}
