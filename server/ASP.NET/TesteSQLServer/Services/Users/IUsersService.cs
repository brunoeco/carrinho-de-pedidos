using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Users
{
    public interface IUsersService 
    {
        public bool CreateUser(CreateUserDto createUserDto);
    }
}
