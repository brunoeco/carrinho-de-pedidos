using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Favorites
{
    public interface IFavoritesRepository 
    {
        public ReadFavoriteDto GetFavoriteById(string id, string userId);

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(string userId);

        public string CreateFavorite(CreateFavoriteDto createFavoriteDto, string userId);

        public void DeleteFavorite(string id, string userId);
    }
}
