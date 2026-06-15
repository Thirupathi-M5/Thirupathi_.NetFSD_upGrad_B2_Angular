using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventDetailsService
    {
        private readonly AddDbContext _context;

        //  DI constructor
        public EventDetailsService(AddDbContext context)
        {
            _context = context;
        }

        // Add Event
        public void AddEvent(EventDetails eventObj)
        {
            _context.Events.Add(eventObj);
            _context.SaveChanges();
        }

        // Get All Events
        public List<EventDetails> GetAllEvents()
        {
            return _context.Events.ToList(); //LINQ
        }

        // Get Event By Id
        public EventDetails GetEventById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        // Update Event
        public void UpdateEvent(EventDetails eventObj)
        {
            _context.Events.Update(eventObj);
            _context.SaveChanges();
        }

        // Delete Event
        public void DeleteEvent(int id)
        {
            var eventObj = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eventObj != null)
            {
                _context.Events.Remove(eventObj);
                _context.SaveChanges();
            }
        }
    }
}