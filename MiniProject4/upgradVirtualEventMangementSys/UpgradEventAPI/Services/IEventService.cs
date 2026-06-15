using DAL.Models;

public interface IEventService
{
    Task<IEnumerable<EventDetails>> GetAllEvents(int page, int pageSize);
    Task<EventDetails> GetEventById(int id);
    Task AddEvent(EventDetails eventDetails);
    Task DeleteEvent(int id);
    Task UpdateEvent(EventDetails eventDetails);
}