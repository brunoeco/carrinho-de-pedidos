using System.Collections.Generic;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Repositories.Interfaces 
{
    public interface IFavoritesRepository 
    {
        public ReadFavoriteDto GetFavoriteById(int id, string userId);

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(string userId);

        public int CreateFavorite(CreateFavoriteDto createFavoriteDto, string userId);

        public void DeleteFavorite(int id, string userId);
    }
}
