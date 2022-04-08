using TesteSQLServer.DTOs;
using TesteSQLServer.Repositories.Users;
using TesteSQLServer.Services.Utils.Hash;

namespace TesteSQLServer.Services.Users
{
    public class UsersService : IUsersService 
    {
        private readonly IHashService HashService;
        private readonly IUsersRepository UsersRepository;

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
