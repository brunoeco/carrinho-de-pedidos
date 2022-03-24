using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Services.Utils;

namespace TesteSQLServer.Services {
    public class SessionService {
        private IConfiguration _configuration;
        private string _connectionString;
        private HashService _hashService;

        public SessionService(IConfiguration configuration, HashService hashService) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
            _hashService = hashService;
        }

        public ReadUserDto Create(CreateSessionDto createSessionDto) {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();
                
                string query = $"SELECT * FROM users WHERE username = '{createSessionDto.Username}'";

                var user = connection.QueryFirstOrDefault<User>(query);

                if (user == null) return null;

                var result = _hashService.VerifyPassword(user.Password_Hash, createSessionDto.Password);

                var readUser = new ReadUserDto() {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.Username
                };

                if(result) return readUser;

                return null;
            }
        }
    }
}
