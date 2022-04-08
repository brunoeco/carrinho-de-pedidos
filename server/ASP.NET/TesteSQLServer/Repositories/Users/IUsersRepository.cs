using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Repositories.Users 
{
    public interface IUsersRepository
    {
        public User GetUserById(string id); 
        public User GetUserByUsername(string userName);
        public void CreateUser(CreateUserDto createUserDto, string passwordHash);
    }
}
