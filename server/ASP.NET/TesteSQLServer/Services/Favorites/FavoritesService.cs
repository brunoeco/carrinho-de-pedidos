using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Favorites;
using TesteSQLServer.Services.Utils.Token;

namespace TesteSQLServer.Services.Favorites
{
    public class FavoritesService : IFavoritesService 
    {
        private readonly IFavoritesRepository FavoritesRepository;
        private readonly ITokenService TokenService;

        public FavoritesService(IFavoritesRepository favoritesRepository, ITokenService tokenService) 
        {
            FavoritesRepository = favoritesRepository;
            TokenService = tokenService;
        }

        public ReadFavoriteDto GetFavoriteById(string id, HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var favorite = FavoritesRepository.GetFavoriteById(id, userId);

            return favorite;
        }

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var favorites = FavoritesRepository.GetAllFavoritesByUserId(userId);

            return favorites;
        }

        public string CreateFavorite(CreateFavoriteDto createFavoriteDto, HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var favoriteId = FavoritesRepository.CreateFavorite(createFavoriteDto, userId);

            return favoriteId;
        }

        public void DeleteFavorite(string id, HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            FavoritesRepository.DeleteFavorite(id, userId);
        }
    }
}
