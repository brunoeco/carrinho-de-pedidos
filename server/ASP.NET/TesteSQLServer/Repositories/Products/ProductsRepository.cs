using Dapper;
using System.Collections.Generic;
using System.Data;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IConnection Connection;

        public ProductsRepository(IConnection connection)
        {
            Connection = connection;
        }
        public IEnumerable<ReadProductDto> GetAllProducts(FilterDto filterDto)
        {

            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string categoryQuery = $"category LIKE @Category";
            string minPriceQuery = $"price >= @MinPrice";
            string maxPriceQuery = filterDto.MaxPrice > -1 ? $"AND price <= @MaxPrice" : "";
            string searchQuery = $"(name LIKE @Search " +
                $"OR description LIKE @Search)";

            string query = $"SELECT *, p.[image-url] as imageUrl " +
                $"FROM products p " +
                $"WHERE {categoryQuery} AND {searchQuery} " +
                $"AND {minPriceQuery} {maxPriceQuery}";

            var parameters = new Dictionary<string, object>
            {
                {"@Category", $"%{filterDto.Category}%" },
                {"@MinPrice", filterDto.MinPrice },
                {"@MaxPrice", filterDto.MaxPrice },
                {"@Search", $"%{filterDto.Search}%" }
            };

            var products = connection.Query<ReadProductDto>(query, parameters);

            return products;
        }
    }
}
