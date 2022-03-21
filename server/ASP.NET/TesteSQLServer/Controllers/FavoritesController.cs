﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase {
        private IConfiguration _configuration;
        private string _connectionString;

        public FavoritesController(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadFavoriteDto[]>> Index([FromRoute] int id) {

            string query = $"SELECT * FROM favorites INNER JOIN products ON favorites.ProductId = products.Id WHERE UserId = {id}";

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var favorites = await connection.QueryAsync<ReadFavoriteDto, Product, ReadFavoriteDto>(query, (favorite, product) => {
                    favorite.Product = product;
                    return favorite;
                });

                return Ok(favorites);
            } 
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateFavoriteDto createFavoriteDto) {

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string query = $"EXEC FavoritesProcedure @UserId, @ProductId, @CreatedAt";
                var values = new { UserId = createFavoriteDto.UserId, ProductId = createFavoriteDto.ProductId, CreatedAt = DateTime.Now.Date.ToString("g") };

                await connection.QueryAsync(query, values);

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Destroy([FromRoute] int id) {
            string query = $"DELETE FROM favorites WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                await connection.QueryAsync(query);

                return NoContent();
            }
        }
    }
}