using Microsoft.AspNetCore.Http;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Utils.Token
{
    public interface ITokenService
    {
        public string GenerateToken(ReadUserDto readUserDto);

        public string RetrieveUserIdFromToken(HttpContext context);
    }
}
