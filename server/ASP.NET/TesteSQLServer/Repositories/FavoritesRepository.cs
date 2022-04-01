using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TesteSQLServer.Database.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Repositories.Interfaces;

namespace TesteSQLServer.Repositories
{
    public class FavoritesRepository : IFavoritesRepository 
    {
        private IConnection Connection;

        public FavoritesRepository(IConnection connection)
        {
            Connection = connection;
        }

        public ReadFavoriteDto GetFavoriteById(int id, string userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"SELECT * FROM favorites INNER JOIN products " +
                    $"ON favorites.ProductId = products.Id WHERE favorites.Id = {id}  AND UserId = {userId}";

                var favorite = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>
                    (query, (favorite, product) => 
                    {
                        favorite.Product = product;
                        return favorite;
                    });

                if (!favorite.Any())
                {
                    return null;
                }

                return favorite.First();
            }
        }

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(string userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"SELECT * FROM favorites INNER JOIN products " +
                    $"ON favorites.ProductId = products.Id WHERE UserId = {userId}";

                var favorites = connection.Query<ReadFavoriteDto, Product, ReadFavoriteDto>
                    (query, (favorite, product) => 
                    {
                        favorite.Product = product;
                        return favorite;
                    });

                return favorites;
            }
        }

        public int CreateFavorite(CreateFavoriteDto createFavoriteDto, string userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"EXEC FavoritesProcedure @UserId, @ProductId, @CreatedAt";
                var values = new
                    {
                        UserId = userId,
                        ProductId = createFavoriteDto.ProductId,
                        CreatedAt = DateTime.Now.Date.ToString("dd/MM/yyyy")
                    };

                var favoriteId = connection.QueryFirst<int>(query, values);

                return favoriteId;
            }
        }

        public void DeleteFavorite(int id, string userId)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = $"DELETE FROM favorites WHERE Id = {id} AND UserId = {userId}";

                connection.Query(query);

                return;
            }
        }
    }
}
