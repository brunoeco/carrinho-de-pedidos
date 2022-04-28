using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Favorites;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase 
    {
        private readonly IFavoritesService FavoriteService;

        public FavoritesController(IFavoritesService favoriteService) 
        {
            FavoriteService = favoriteService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ReadFavoriteDto> Show([FromRoute] string id) 
        {
            var favorite = FavoriteService.GetFavoriteById(id, this.HttpContext);

            if (favorite != null)
            {
                return Ok(favorite);
            }

            return NotFound();
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<ReadFavoriteDto>> Index()
        {
            var favorites = FavoriteService.GetAllFavoritesByUserId(this.HttpContext);

            return Ok(favorites);            
        }

        [HttpPost]
        [Authorize]
        public ActionResult<string> Create([FromBody] CreateFavoriteDto createFavoriteDto) 
        {
            var favoriteId = FavoriteService.CreateFavorite(createFavoriteDto, this.HttpContext);

            return Ok(favoriteId);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Destroy([FromRoute] string id)
        {
            FavoriteService.DeleteFavorite(id, this.HttpContext);

            return Ok();
        }
    }
}
