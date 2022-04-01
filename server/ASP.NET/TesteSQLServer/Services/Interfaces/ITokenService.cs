using Microsoft.AspNetCore.Http;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(ReadUserDto readUserDto);

        public string RetrieveUserIdFromToken(HttpContext context);
    }
}
