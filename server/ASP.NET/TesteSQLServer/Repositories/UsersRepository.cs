using Dapper;
using System.Data;
using TesteSQLServer.Database.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Repositories.Interfaces;

namespace TesteSQLServer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private IConnection Connection;

        public UsersRepository(IConnection connection)
        {
            Connection = connection;
        }

        public User GetUserById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                var query = $"SELECT * FROM users WHERE Id = {id}";
                var user = connection.QueryFirstOrDefault<User>(query);

                return user;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                var query = $"SELECT * FROM users WHERE username = '{username}'";
                var user = connection.QueryFirstOrDefault<User>(query);

                return user;
            }
        }

        public void CreateUser(CreateUserDto createUserDto, string passwordHash) 
        {
            using (IDbConnection connection = Connection.GetConnection()) 
            {
                connection.Open();

                var query = $"INSERT INTO users (Name, Email, Username, Password_Hash) " +
                    $"VALUES ('{createUserDto.Name}', '{createUserDto.Email}', '{createUserDto.Username}', '{passwordHash}')";

                connection.Query(query);

                return;
            }
        }

    }
}
