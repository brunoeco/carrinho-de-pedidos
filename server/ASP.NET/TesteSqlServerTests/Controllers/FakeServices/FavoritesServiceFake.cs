using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Services.Favorites;

namespace TesteSqlServerTests.Controllers.FakeServices
{
    class FavoritesServiceFake : IFavoritesService
    {
        public readonly List<Favorite> Favorites;

        public FavoritesServiceFake()
        {
            Favorites = new List<Favorite>()
            {
                new Favorite(){ Id = new Guid("0b216ac3-1f34-47bf-9cea-e11261111866"), CreatedAt = DateTime.Now, ProductId = new Guid("fe3035f2-5f02-43fa-8e6c-4d0c093a606a"), UserId = new Guid("a479cb45-28a8-4f93-a246-eebc912129fc")},
                new Favorite(){ Id = new Guid("cc66e533-31f0-4c35-93be-3c4c957609ac"), CreatedAt = DateTime.Now, ProductId = new Guid("4a792784-1d66-45a1-ad72-d2127c78440d"), UserId = new Guid("a479cb45-28a8-4f93-a246-eebc912129fc")},
                new Favorite(){ Id = new Guid("08747565-7f6f-4bb4-a950-94c5dacde065"), CreatedAt = DateTime.Now, ProductId = new Guid("74d1db14-1477-484d-a573-39948cfc04bc"), UserId = new Guid("5e506283-51d8-4982-a1dd-7af40006de41")}

            };
        }

        public string CreateFavorite(CreateFavoriteDto createFavoriteDto, HttpContext context)
        {
            var favoriteId = Guid.NewGuid();

            Favorites.Add(new Favorite()
            {
                Id = favoriteId,
                CreatedAt = DateTime.Now,
                ProductId = createFavoriteDto.ProductId,
                UserId = Guid.NewGuid()
            });

            return favoriteId.ToString();
        }

        public void DeleteFavorite(string id, HttpContext context)
        {
            return;
        }

        public IEnumerable<ReadFavoriteDto> GetAllFavoritesByUserId(HttpContext context)
        {
            var guidId = new Guid("a479cb45-28a8-4f93-a246-eebc912129fc");
            var favorites = Favorites.Where(item => item.UserId == guidId);

            if (favorites == null)
            {
                return null;
            }

            var favoritesDto = favorites.ToList().Select(item => new ReadFavoriteDto()
            {
                Id = item.Id,
                UserId = item.UserId,
                ProductId = item.ProductId,
                CreatedAt = item.CreatedAt
            });

            return favoritesDto.ToList();
        }

        public ReadFavoriteDto GetFavoriteById(string id, HttpContext context)
        {
            var guidId = new Guid(id);
            var favorite = Favorites.Where(item => item.Id == guidId).FirstOrDefault();

            if (favorite == null) 
            {
                return null;
            }

            return new ReadFavoriteDto()
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                ProductId = favorite.ProductId,
                CreatedAt = favorite.CreatedAt
            };
        }
    }
}
