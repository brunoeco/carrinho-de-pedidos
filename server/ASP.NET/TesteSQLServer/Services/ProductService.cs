using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Models;

namespace TesteSQLServer.Services {
    public class ProductService {
        private IConfiguration _configuration;
        private string _connectionString;

        public ProductService(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        public IEnumerable<Product> Index(
            string category,
            decimal min_price,
            decimal max_price,
            string search
            ) {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string categoryQuery = $"category LIKE '%{category}%'";
                string minPriceQuery = $"price >= {min_price}";
                string maxPriceQuery = max_price > -1 ? $"AND price <= {max_price}" : "";
                string searchQuery = $"(name LIKE '%{search}%' OR description LIKE '%{search}%')";

                string query = $"SELECT * FROM products WHERE {categoryQuery} AND {searchQuery} " +
                    $"AND {minPriceQuery} {maxPriceQuery}";

                var products = connection.Query<Product>(query);

                return products;
            }
        }
    }
}
