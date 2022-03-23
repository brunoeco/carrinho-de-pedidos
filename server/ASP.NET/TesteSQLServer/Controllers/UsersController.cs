using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TesteSQLServer.DTOs;
using TesteSQLServer.Models;
using TesteSQLServer.Services;
using TesteSQLServer.Services.Utils;

namespace TesteSQLServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private UserService _userService;

        public UsersController(UserService userService) {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto createUserDto) {
            var result = _userService.Create(createUserDto);

            if (!result) return BadRequest("Nome de usuário indisponível.");

            return NoContent();
        }
    }
}
