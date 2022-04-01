using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Services
{
    public class SessionsService : ISessionsService 
    {
        private IHashService HashService;
        private ITokenService TokenService;
        private IUsersRepository UsersRepository;

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

            var result = HashService.VerifyPassword(user.Password_Hash, createSessionDto.Password);

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
