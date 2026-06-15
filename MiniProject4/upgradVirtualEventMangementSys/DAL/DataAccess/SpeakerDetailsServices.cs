using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SpeakerDetailsService
    {
        private readonly AddDbContext _context;

        // Dependency Injection constructor
        public SpeakerDetailsService(AddDbContext context)
        {
            _context = context;
        }

        // Add Speaker
        public void AddSpeaker(SpeakerDetails speaker)
        {
            _context.Speakers.Add(speaker);
            _context.SaveChanges();
        }

        // Get All Speakers
        public List<SpeakerDetails> GetAllSpeakers()
        {
            return _context.Speakers.ToList();
        }

        // Get Speaker By Id
        public SpeakerDetails GetSpeakerById(int id)
        {
            return _context.Speakers.FirstOrDefault(s => s.SpeakerId == id);
        }

        // Update Speaker
        public void UpdateSpeaker(SpeakerDetails speaker)
        {
            _context.Speakers.Update(speaker);
            _context.SaveChanges();
        }

        // Delete Speaker
        public void DeleteSpeaker(int id)
        {
            var speaker = _context.Speakers.FirstOrDefault(s => s.SpeakerId == id);
            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                _context.SaveChanges();
            }
        }
    }
}