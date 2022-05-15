using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Products;

namespace TesteSqlServerTests.Services.FakeRepositories
{
    class ProductsRepositoryFake : IProductsRepository
    {
        IEnumerable<ReadProductDto> Products;

        public ProductsRepositoryFake()
        {
            Products = new List<ReadProductDto>()
            {
                new ReadProductDto(){ Id = new Guid("0b216ac3-1f34-47bf-9cea-e11261111866"), Name = "Produto 1", Category = "acessorios", Description = "descricao 1", ImageUrl = "url1", Price = 550.00m},
                new ReadProductDto(){ Id = new Guid("cc66e533-31f0-4c35-93be-3c4c957609ac"), Name = "Produto 2", Category = "acessorios", Description = "descricao 2", ImageUrl = "url2", Price = 300.00m},
                new ReadProductDto(){ Id = new Guid("08747565-7f6f-4bb4-a950-94c5dacde065"), Name = "Produto 3", Category = "componentes", Description = "descricao 3", ImageUrl = "url3", Price = 1900.00m}

            };
        }

        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto)
        {
            return Products;
        }
    }
}
