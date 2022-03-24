using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Utils;
using Dapper;

namespace TesteSQLServer.Services {
    public class UserService {
        private IConfiguration _configuration;
        private string _connectionString;
        private HashService _hashService;


        public UserService(IConfiguration configuration, HashService hashService) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");

            _hashService = hashService;
        }

        public bool Create(CreateUserDto createUserDto) {

            using (SqlConnection connection = new SqlConnection(_connectionString) ) {
                connection.Open();

                var query = $"SELECT username FROM users WHERE username = '{createUserDto.Username}'";

                var result = connection.QueryFirstOrDefault<string>(query);

                if (result != null) return false;

                var passwordhash = _hashService.HashPassword(createUserDto.Password);

                query = $"INSERT INTO users (Name, Email, Username, Password_Hash) " +
                    $"VALUES ('{createUserDto.Name}', '{createUserDto.Email}', '{createUserDto.Username}', '{passwordhash}')";

                connection.Query(query);

                return true;
            }
        }
    }
}
