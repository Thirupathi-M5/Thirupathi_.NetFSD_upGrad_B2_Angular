using DAL.DataAccess;
using DAL.Models;

namespace DAL.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly AddDbContext _context;

        public SpeakerRepository(AddDbContext context)
        {
            _context = context;
        }

        public List<SpeakerDetails> GetAll()
        {
            return _context.Speakers.ToList();
        }

        public SpeakerDetails GetById(int id)
        {
            return _context.Speakers.Find(id);
        }

        public void Add(SpeakerDetails speaker)
        {
            _context.Speakers.Add(speaker);
            _context.SaveChanges();
        }

        public void Update(SpeakerDetails speaker)
        {
            _context.Speakers.Update(speaker);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Speakers.Find(id);
            if (data != null)
            {
                _context.Speakers.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}