using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Favorites
{
    public interface IFavoritesService
    {
        public ReadFavoriteDto GetFavoriteById(string id, HttpContext context);

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(HttpContext context);

        public string CreateFavorite(CreateFavoriteDto createFavoriteDto, HttpContext context);

        public void DeleteFavorite(string id, HttpContext context);
    }
}
