using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Services {
    public class FavoriteService {
        private IConfiguration _configuration;
        private string _connectionString;

        public FavoriteService(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        public ReadFavoriteDto Show(int id) {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string query = $"SELECT * FROM favorites INNER JOIN products " +
                    $"ON favorites.ProductId = products.Id WHERE favorites.Id = {id}";

                var favorite = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>(query, (favorite, product) => {
                    favorite.Product = product;
                    return favorite;
                });

                if (!favorite.Any()) return null;

                return favorite.First();
            }
        }

        public IEnumerable<ReadFavoriteDto> Index(int userId) {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string query = $"SELECT * FROM favorites INNER JOIN products " +
                    $"ON favorites.ProductId = products.Id WHERE UserId = {userId}";

                var favorites = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>(query, (favorite, product) => {
                    favorite.Product = product;
                    return favorite;
                });

                return favorites;
            }
        }

        public int Create(CreateFavoriteDto createFavoriteDto) {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string query = $"EXEC FavoritesProcedure @UserId, @ProductId, @CreatedAt";
                var values = new { UserId = createFavoriteDto.UserId, ProductId = createFavoriteDto.ProductId, CreatedAt = DateTime.Now.Date.ToString("dd/MM/yyyy") };

                var favoriteId = connection.QueryFirst<int>(query, values);

                return favoriteId;
            }
        }

        public void Detroy(int id) {

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                string query = $"DELETE FROM favorites WHERE id = {id}";

                connection.Query(query);

                return;
            }
        }
    }
}
