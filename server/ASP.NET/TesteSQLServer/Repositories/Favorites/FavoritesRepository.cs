using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Repositories.Favorites
{
    public class FavoritesRepository : IFavoritesRepository 
    {
        private readonly IConnection Connection;

        public FavoritesRepository(IConnection connection)
        {
            Connection = connection;
        }

        public ReadFavoriteDto GetFavoriteById(string id, string userId)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string query = $"SELECT f.id, f.[product-id] AS productId, f.[user-id] AS userId, " +
                $"f.[created-at] AS createdAt, p.*, p.[image-url] AS imageUrl " +
                $"FROM favorites f INNER JOIN products p " +
                $"ON f.[product-id] = p.Id WHERE f.Id = @Id  AND f.[user-id] = @UserId";

            var parameters = new Dictionary<string, object>
            {
                {"@UserId", userId },
                {"@Id", id },
            };

            var favorite = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>
                (query, (favorite, product) => 
                {
                    favorite.Product = product;
                    return favorite;
                }, parameters);

            if (!favorite.Any())
            {
                return null;
            }

            return favorite.First();
        }

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(string userId)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string query = $"SELECT f.id, f.[created-at] AS createdAt, f.[user-id] AS userId, " +
                $"f.[product-id] AS productId, p.*, p.[image-url] AS imageUrl " +
                $"FROM favorites f INNER JOIN products p " +
                $"ON f.[product-id] = p.Id WHERE f.[user-id] = @UserId";

            var dictionary = new Dictionary<string, object>
            {
                {"@UserId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            var favorites = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>
                (query, (favorite, product) =>
                {
                    favorite.Product = product;
                    return favorite;
                }, parameters);

            return favorites;
        }

        public string CreateFavorite(CreateFavoriteDto createFavoriteDto, string userId)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string query = $"INSERT INTO Favorites(id,[user-id], [product-id], [created-at]) " +
                $"VALUES (@Id, @UserId, @ProductId, @CreatedAt) ";

            var dictionary = new Dictionary<string, object>
            {
                { "@Id", Guid.NewGuid() },
                { "@UserId", userId },
                { "@ProductId", createFavoriteDto.ProductId },
                { "@CreatedAt", DateTime.Now.Date.ToString("dd/MM/yyyy") }
            };

            var parameters = new DynamicParameters(dictionary);

            connection.Query(query, parameters);

            var favoriteId = dictionary["@Id"];

            return favoriteId.ToString();
        }

        public void DeleteFavorite(string id, string userId)
        {

            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            string query = $"DELETE FROM favorites WHERE Id = @Id AND [user-id] = @UserId";

            var dictionary = new Dictionary<string, object>
            {
                {"@Id", id },
                {"@UserId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            connection.Query(query, parameters);

            return;
        }
    }
}
