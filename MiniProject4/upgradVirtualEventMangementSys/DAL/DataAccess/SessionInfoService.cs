using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class SessionInfoService
    {
        private readonly AddDbContext _context;

        // Dependency Injection constructor
        public SessionInfoService(AddDbContext context)
        {
            _context = context;
        }

        //  ADD SESSION
        public async Task AddSession(SessionInfo session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        // GET ALL SESSIONS
        public async Task<List<SessionInfo>> GetAllSessions()
        {
            return await _context.Sessions.ToListAsync();
        }

        // GET BY ID
        public async Task<SessionInfo> GetSessionById(int id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        //UPDATE SESSION
        public async Task UpdateSession(SessionInfo session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        // DELETE SESSION
        public async Task DeleteSession(int id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}