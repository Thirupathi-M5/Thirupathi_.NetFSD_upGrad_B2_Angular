using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class ParticipantEventDetailsService
    {
        private readonly AddDbContext _context;

        public ParticipantEventDetailsService(AddDbContext context)
        {
            _context = context;
        }
        public void RegisterEvent(string emailId, int eventId)
        {
            var exists = _context.ParticipantEventDetails
                .Any(x => x.ParticipantEmailId == emailId && x.EventId == eventId);

            if (!exists)
            {
                var data = new ParticipantEventDetails
                {
                    ParticipantEmailId = emailId,
                    EventId = eventId,
                    IsAttended = false,
                    SessionId = 0 
                };

                _context.ParticipantEventDetails.Add(data);
                _context.SaveChanges();
            }
        }

        // ADD
        public void Add(ParticipantEventDetails data)
        {
            _context.ParticipantEventDetails.Add(data);
            _context.SaveChanges();
        }

        // GET ALL
        public List<ParticipantEventDetails> GetAll()
        {
            return _context.ParticipantEventDetails.ToList();
        }

        // GET BY ID
        public ParticipantEventDetails GetById(int id)
        {
            return _context.ParticipantEventDetails.FirstOrDefault(x => x.Id == id);
        }

        // UPDATE
        public void Update(ParticipantEventDetails data)
        {
            _context.ParticipantEventDetails.Update(data);
            _context.SaveChanges();
        }

        // DELETE
        public void Delete(int id)
        {
            var data = _context.ParticipantEventDetails.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _context.ParticipantEventDetails.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}