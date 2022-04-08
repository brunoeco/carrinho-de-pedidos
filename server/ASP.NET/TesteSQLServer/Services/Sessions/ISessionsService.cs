using TesteSQLServer.DTOs;

namespace TesteSQLServer.Services.Sessions
{
    public interface ISessionsService 
    {
        public ReadSessionDto CreateSession(CreateSessionDto createSessionDto);
    }
}
