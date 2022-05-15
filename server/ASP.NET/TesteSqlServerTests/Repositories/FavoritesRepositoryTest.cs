using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Favorites;
using Xunit;

namespace TesteSqlServerTests.Repositories
{
    public class FavoritesRepositoryTest
    {
        FavoritesRepository Repository;

        public FavoritesRepositoryTest()
        {
            Moq.Mock<IConnection> mock = new Moq.Mock<IConnection>();
            mock.Setup(x => x.GetConnection()).Returns(new SqlConnection());
            Repository = new FavoritesRepository(mock.Object);
        }

        [Fact]
        public void GetAllFavoritesByUserId_WhenCalled_ReturnListOfFavoritesByUser()
        {
            var userId = Guid.NewGuid();
            var favorites = Repository.GetAllFavoritesByUserId(userId.ToString());

            Assert.IsType<List<ReadFavoriteDto>>(favorites);
        }
    }
}
