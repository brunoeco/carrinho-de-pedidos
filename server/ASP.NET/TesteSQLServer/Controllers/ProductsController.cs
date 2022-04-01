using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase 
    {
        private IProductsService ProductService;

        public ProductsController(IProductsService productService) 
        {
            ProductService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Index([FromQuery] FilterDto filterDto) 
        {

            var products = ProductService.GetAllProducts(filterDto);

            return Ok(products);
        }
    }
}
