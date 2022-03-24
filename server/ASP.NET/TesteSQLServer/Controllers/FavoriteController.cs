using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Services;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase {
        private FavoriteService _favoriteService;

        public FavoriteController(FavoriteService favoriteService) {
            _favoriteService = favoriteService;
        }

        [HttpGet("{id}")]
        public ActionResult<ReadFavoriteDto> Show([FromRoute] int id) {
            var favorite = _favoriteService.Show(id);

            if (favorite != null) return Ok(favorite);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ReadFavoriteDto>> Index([FromQuery] int userId) {
            var favorites = _favoriteService.Index(userId);

            return Ok(favorites);            
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] CreateFavoriteDto createFavoriteDto) {
            var favoriteId = _favoriteService.Create(createFavoriteDto);

            return Ok(favoriteId);
        }

        [HttpDelete("{id}")]
        public ActionResult Destroy([FromRoute] int id) {
            _favoriteService.Detroy(id);

            return NoContent();
        }
    }
}
