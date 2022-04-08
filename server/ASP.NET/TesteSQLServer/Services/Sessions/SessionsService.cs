using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Users;
using TesteSQLServer.Services.Utils.Hash;
using TesteSQLServer.Services.Utils.Token;

namespace TesteSQLServer.Services.Sessions
{
    public class SessionsService : ISessionsService 
    {
        private readonly IHashService HashService;
        private readonly ITokenService TokenService;
        private readonly IUsersRepository UsersRepository;

        public SessionsService(IUsersRepository usersRepository, IHashService hashService, ITokenService tokenService) 
        {
            HashService = hashService;
            TokenService = tokenService;
            UsersRepository = usersRepository;
        }

        public ReadSessionDto CreateSession(CreateSessionDto createSessionDto) 
        {
            var user = UsersRepository.GetUserByUsername(createSessionDto.Username);
            if (user == null)
            {
                return null;
            }

            var result = HashService.VerifyPassword(user.PasswordHash, createSessionDto.Password);

            if (!result)
            {
                return null;
            }

            var readUser = new ReadUserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username
            };

            var token = TokenService.GenerateToken(readUser);

            return new ReadSessionDto { User = readUser, Token = token };
        }
    }
}
