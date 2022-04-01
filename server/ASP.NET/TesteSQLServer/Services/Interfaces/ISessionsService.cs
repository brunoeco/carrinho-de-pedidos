using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Interfaces
{
    public interface ISessionsService 
    {
        public ReadSessionDto CreateSession(CreateSessionDto createSessionDto);
    }
}
