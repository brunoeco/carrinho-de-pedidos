using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Utils.Token
{
    public class TokenService : ITokenService 
    {

        public string GenerateToken(ReadUserDto readUserDto) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Settings.SecretBytes();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("UserId", readUserDto.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string RetrieveUserIdFromToken(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            if(identity.Claims.Any()) return identity.FindFirst("UserId").Value;

            return "0";
        }
    }
}
