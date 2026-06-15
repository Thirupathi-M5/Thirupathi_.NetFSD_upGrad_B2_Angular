using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace UpgradEventAPI.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly AddDbContext _context;

        public SpeakerService(AddDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpeakerDetails>> GetAllSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task AddSpeaker(SpeakerDetails speaker)
        {
            await _context.Speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpeaker(int id)
        {
            var speaker = await _context.Speakers.FindAsync(id);

            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                await _context.SaveChangesAsync();
            }
        }
    }
}