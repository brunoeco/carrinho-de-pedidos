using TesteSQLServer.DTOs;
using TesteSQLServer.Models;

namespace TesteSQLServer.Repositories.Interfaces 
{
    public interface IUsersRepository
    {
        public User GetUserById(int id); 
        public User GetUserByUsername(string userName);
        public void CreateUser(CreateUserDto createUserDto, string passwordHash);
    }
}
