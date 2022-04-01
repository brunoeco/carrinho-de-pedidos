using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Interfaces;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Services
{
    public class UsersService : IUsersService 
    {
        private IHashService HashService;
        private IUsersRepository UsersRepository;

        public UsersService(IUsersRepository usersRepository, IHashService hashService) 
        {
            HashService = hashService;
            UsersRepository = usersRepository;
        }

        public bool CreateUser(CreateUserDto createUserDto) 
        {
            var userExists = UsersRepository.GetUserByUsername(createUserDto.Username);
            if (userExists != null) 
            {
                return false;
            }

            var passwordhash = HashService.HashPassword(createUserDto.Password);
            UsersRepository.CreateUser(createUserDto, passwordhash);

            return true;
        }
    }
}
