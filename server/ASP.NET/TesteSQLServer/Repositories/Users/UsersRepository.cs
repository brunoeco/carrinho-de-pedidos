using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnection Connection;

        public UsersRepository(IConnection connection)
        {
            Connection = connection;
        }

        public User GetUserById(string id)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            var query = $"SELECT u.*, u.[password-hash] AS passwordHash FROM users u WHERE Id = @Id";

            var dictionary = new Dictionary<string, object>
            {
                {"@Id", id }
            };

            var parameters = new DynamicParameters(dictionary);

            var user = connection.QueryFirstOrDefault<User>(query, parameters);

            return user;
        }

        public User GetUserByUsername(string username)
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            var query = $"SELECT u.*, u.[password-hash] AS passwordHash FROM users u WHERE username = @Username";

            var dictionary = new Dictionary<string, object>
            {
                {"@Username", username }
            };

            var parameters = new DynamicParameters(dictionary);

            var user = connection.QueryFirstOrDefault<User>(query, parameters);

            return user;
        }

        public void CreateUser(CreateUserDto createUserDto, string passwordHash) 
        {
            using IDbConnection connection = Connection.GetConnection();
            connection.Open();

            var query = $"INSERT INTO users (Id, Name, Email, Username, [Password-Hash]) " +
                $"VALUES (@Id, @Name, @Email, @Username, @PasswordHash)";

            var dictionary = new Dictionary<string, object>() {
                    { "@Id", Guid.NewGuid() },
                    { "@Name", createUserDto.Name },
                    { "@Email", createUserDto.Email },
                    { "@Username", createUserDto.Username },
                    { "@PasswordHash", passwordHash }
                };

            var parameters = new DynamicParameters(dictionary);

            connection.Query(query, parameters);

            return;
        }

    }
}
