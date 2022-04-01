using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface IUsersService 
    {
        public bool CreateUser(CreateUserDto createUserDto);
    }
}
