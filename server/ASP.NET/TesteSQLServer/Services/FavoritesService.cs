using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Services
{
    public class FavoritesService : IFavoritesService 
    {
        private IFavoritesRepository FavoritesRepository;
        private ITokenService TokenService;

        public FavoritesService(IFavoritesRepository favoritesRepository, ITokenService tokenService) 
        {
            FavoritesRepository = favoritesRepository;
            TokenService = tokenService;
        }

        public ReadFavoriteDto GetFavoriteById(int id, HttpContext context) 
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

        public int CreateFavorite(CreateFavoriteDto createFavoriteDto, HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            var favoriteId = FavoritesRepository.CreateFavorite(createFavoriteDto, userId);

            return favoriteId;
        }

        public void DeleteFavorite(int id, HttpContext context) 
        {
            var userId = TokenService.RetrieveUserIdFromToken(context);
            FavoritesRepository.DeleteFavorite(id, userId);
        }
    }
}
