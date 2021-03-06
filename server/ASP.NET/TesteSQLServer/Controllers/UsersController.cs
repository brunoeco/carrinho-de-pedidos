using Microsoft.AspNetCore.Mvc;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Users;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase 
    {
        private readonly IUsersService UserService;

        public UsersController(IUsersService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto createUserDto)
        {
            var result = UserService.CreateUser(createUserDto);

            if (!result)
            {
                return BadRequest("Nome de usuário indisponível.");
            }

            return NoContent();
        }
    }
}
