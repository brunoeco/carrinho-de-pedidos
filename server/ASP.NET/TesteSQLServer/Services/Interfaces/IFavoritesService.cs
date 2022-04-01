using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface IFavoritesService
    {
        public ReadFavoriteDto GetFavoriteById(int id, HttpContext context);

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(HttpContext context);

        public int CreateFavorite(CreateFavoriteDto createFavoriteDto, HttpContext context);

        public void DeleteFavorite(int id, HttpContext context);
    }
}
