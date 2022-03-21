using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase {
        private IConfiguration _configuration;
        private string _connectionString;

        public SessionController(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        [HttpPost]
        public async Task<ActionResult<ReadUserDto>> Create([FromBody] CreateSessionDto createSessionDto) {
            string query = $"SELECT * FROM users WHERE username = '{createSessionDto.Username}' AND password = '{createSessionDto.Password}'";

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var user = await connection.QueryFirstOrDefaultAsync<ReadUserDto>(query);

                if (user == null) return Unauthorized("Falha ao fazer login");

                return user;
            }
        }
    }
}
