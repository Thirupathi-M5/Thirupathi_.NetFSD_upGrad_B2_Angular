using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace UpgradEventAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly AddDbContext _context;

        public SessionService(AddDbContext context)
        {
            _context = context;
        }

        public async Task AddSession(SessionInfo session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SessionInfo>> GetSessionsByEvent(int eventId)
        {
            return await _context.Sessions
                .Where(s => s.EventId == eventId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SessionInfo>> GetAllSessions()
        {
            return await _context.Sessions
                .ToListAsync();
        }

        public async Task DeleteSession(int id)
        {
            var session =
                await _context.Sessions.FindAsync(id);

            if (session != null)
            {
                _context.Sessions.Remove(session);

                await _context.SaveChangesAsync();
            }
        }
    }
}