using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace UpgradEventAPI.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly AddDbContext _context;

        public ParticipantService(AddDbContext context)
        {
            _context = context;
        }

        // Register for Event
        public async Task RegisterEvent(ParticipantEventDetails data)
        {
            await _context.ParticipantEventDetails.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        // View Registered Events
        public async Task<IEnumerable<ParticipantEventDetails>> GetUserEvents(string email)
        {
            return await _context.ParticipantEventDetails  //linq
                .Where(x => x.ParticipantEmailId == email)
                .ToListAsync();
        }

        // Mark Attendance
        public async Task MarkAttendance(int id)
        {
            var record = await _context.ParticipantEventDetails.FindAsync(id);

            if (record != null)
            {
                record.IsAttended = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}