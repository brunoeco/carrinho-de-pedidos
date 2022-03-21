using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TesteSQLServer.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private IConfiguration _configuration;
        private string _connectionString;

        public ProductsController(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        [HttpGet]
        public async Task<ActionResult<Product[]>> Index([FromQuery]
            string category = "", 
            decimal min_price = 0, 
            decimal max_price = -1, 
            string search = ""
            ) {

            string categoryQuery = $"category LIKE '%{category}%'";
            string minPriceQuery = $"price >= {min_price}";
            string maxPriceQuery = max_price > -1 ? $"AND price <= {max_price}" : "";
            string searchQuery = $"(name LIKE '%{search}%' OR description LIKE '%{search}%')";

            string query = $"SELECT * FROM products WHERE {categoryQuery} AND {searchQuery} AND {minPriceQuery} {maxPriceQuery}";

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var products = await connection.QueryAsync<Product>(query);

                return Ok(products);
            }
        }
    }
}
