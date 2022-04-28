using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSQLServer.Controllers;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Favorites;
using TesteSqlServerTests.Controllers.FakeServices;
using Xunit;

namespace TesteSqlServerTests.Controllers
{
    public class FavoritesControllerTest
    {
        FavoritesController Controller;
        IFavoritesService Service;

        public FavoritesControllerTest()
        {
            Service = new FavoritesServiceFake();
            Controller = new FavoritesController(Service);
        }

        [Fact]
        public void Show_WhenCalled_ReturnsOkResult()
        {
            var id = "0b216ac3-1f34-47bf-9cea-e11261111866";
            var okResult = Controller.Show(id);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }


        [Fact]
        public void Show_WhenCalled_ReturnsOneFavoriteObject()
        {
            var id = "0b216ac3-1f34-47bf-9cea-e11261111866";
            var okResult = Controller.Show(id).Result as OkObjectResult;

            var item = Assert.IsType<ReadFavoriteDto>(okResult.Value);

            Assert.Equal(new Guid(id), item.Id);
        }

        [Fact]
        public void Show_WhenCalled_InvalidId_ReturnsNotFound()
        {
            var id = "0b216ac3-1f34-47bf-9cea-e11261111868";
            var notFoundResult = Controller.Show(id);

            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Index_WhenCalled_ReturnsOkResult()
        {
            var okResult = Controller.Index();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }


        [Fact]
        public void Index_WhenCalled_ReturnsTwoFavoriteObject()
        {
            var okResult = Controller.Index().Result as OkObjectResult;

            var item = Assert.IsType<List<ReadFavoriteDto>>(okResult.Value);

            Assert.Equal(2, item.Count());
        }

        [Fact]
        public void Create_WhenCalled_ReturnsOkResult()
        {
            var favoriteDto = new CreateFavoriteDto()
            {
                ProductId = Guid.NewGuid()
            };

            var okResult = Controller.Create(favoriteDto);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Destroy_WhenCalled_ReturnsOkResult()
        {
            var id = "0b216ac3-1f34-47bf-9cea-e11261111866";
            var okResult = Controller.Destroy(id);

            Assert.IsType<OkResult>(okResult);
        }
    }
}
