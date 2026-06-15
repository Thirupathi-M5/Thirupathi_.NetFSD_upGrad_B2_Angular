using DAL.Models;
using DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace UpgradEventAPI.Services;
using Microsoft.Extensions.Caching.Memory;
public class EventService : IEventService
{
    private readonly AddDbContext _context;

    private readonly IMemoryCache _cache;

    public EventService(AddDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<IEnumerable<EventDetails>> GetAllEvents(int page, int pageSize)
    {
       // string cacheKey = $"events_{page}_{pageSize}";

        //if (!_cache.TryGetValue(cacheKey, out List<EventDetails> events))
        //{
        //    if (page <= 0)
        //        page = 1;

        //    if (pageSize <= 0)
        //        pageSize = 50;

        //    events = await _context.Events
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    var cacheOptions = new MemoryCacheEntryOptions()
        //        .SetSlidingExpiration(TimeSpan.FromMinutes(5));

        //    _cache.Set(cacheKey, events, cacheOptions);
        //}

        //return events;

       
        if (page <= 0) //paging used
            page = 1;

        if (pageSize <= 0)
            pageSize = 50;

        return await _context.Events
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    
    }

    public async Task<EventDetails> GetEventById(int id)
    {
        return await _context.Events.FindAsync(id); // Correct DbSet
    }

    public async Task AddEvent(EventDetails eventDetails)
    {
        await _context.Events.AddAsync(eventDetails);
        await _context.SaveChangesAsync();

        _cache.Remove("events_1_5"); // simple invalidation
    }
    public async Task DeleteEvent(int id)
    {
        var eventObj = await _context.Events.FindAsync(id);

        if (eventObj != null)
        {
            _context.Events.Remove(eventObj);
            await _context.SaveChangesAsync();

            _cache.Remove("events_1_5");
        }
    }

    public async Task UpdateEvent(EventDetails eventDetails)
    {
        _context.Events.Update(eventDetails);

        await _context.SaveChangesAsync();

        _cache.Remove("events_1_5");
    }
}