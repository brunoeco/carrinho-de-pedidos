using Dapper;
using System.Collections.Generic;
using System.Data;
using TesteSQLServer.Database.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;

namespace TesteSQLServer.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private IConnection Connection;

        public ProductsRepository(IConnection connection)
        {
            Connection = connection;
        }
        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string categoryQuery = $"category LIKE '%{filterDto.Category}%'";
                string minPriceQuery = $"price >= {filterDto.MinPrice}";
                string maxPriceQuery = filterDto.MaxPrice > -1 ? $"AND price <= {filterDto.MaxPrice}" : "";
                string searchQuery = $"(name LIKE '%{filterDto.Search}%' " +
                    $"OR description LIKE '%{filterDto.Search}%')";

                string query = $"SELECT * FROM products WHERE {categoryQuery} AND {searchQuery} " +
                    $"AND {minPriceQuery} {maxPriceQuery}";

                var products = connection.Query<ReadProductDto>(query);

                return products;
            }
        }
    }
}
