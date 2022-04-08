using Microsoft.AspNetCore.Mvc;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Sessions;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionsService SessionService;

        public SessionsController(ISessionsService sessionService) 
        {
            SessionService = sessionService;
        }

        [HttpPost]
        public ActionResult<ReadSessionDto> Create([FromBody] CreateSessionDto createSessionDto) 
        {
            var user = SessionService.CreateSession(createSessionDto);

            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized("Usuário ou senha incorretos");
        }
    }
}
