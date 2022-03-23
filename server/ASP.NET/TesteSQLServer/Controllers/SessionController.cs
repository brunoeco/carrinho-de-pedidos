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
using TesteSQLServer.Services;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase {
        private SessionService _sessionService;

        public SessionController(SessionService sessionService) {
            _sessionService = sessionService;
        }

        [HttpPost]
        public ActionResult<ReadUserDto> Create([FromBody] CreateSessionDto createSessionDto) {
            var user = _sessionService.Create(createSessionDto);

            if(user != null) return Ok(user);

            return Unauthorized("Usuário ou senha incorretos");
        }
    }
}
