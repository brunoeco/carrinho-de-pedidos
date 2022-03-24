using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TesteSQLServer.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TesteSQLServer.Services;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private ProductService _productService;

        public ProductController(ProductService productService) {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Index([FromQuery]
            string category = "", 
            decimal min_price = 0, 
            decimal max_price = -1, 
            string search = ""
            ) {

            var products = _productService.Index(category, min_price, max_price, search);

            return Ok(products);
        }
    }
}
