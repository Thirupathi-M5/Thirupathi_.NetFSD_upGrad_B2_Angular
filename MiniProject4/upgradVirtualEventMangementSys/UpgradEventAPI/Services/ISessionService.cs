using DAL.Models;

public interface ISessionService
{
    Task AddSession(SessionInfo session);
    Task<IEnumerable<SessionInfo>> GetSessionsByEvent(int eventId);

    Task<IEnumerable<SessionInfo>> GetAllSessions();
    Task DeleteSession(int id);
}