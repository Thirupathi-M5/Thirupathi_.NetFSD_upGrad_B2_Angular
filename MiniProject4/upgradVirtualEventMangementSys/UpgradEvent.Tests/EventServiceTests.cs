using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.DataAccess;
using DAL.Models;
using UpgradEventAPI.Services;
using Microsoft.Extensions.Caching.Memory;

namespace UpgradEvent.Tests
{
    public class EventServiceTests
    {
        private AddDbContext _context;
        private EventService _service;
        private IMemoryCache _cache;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AddDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new AddDbContext(options);

            var cacheOptions = new MemoryCacheOptions();
            _cache = new MemoryCache(cacheOptions);

            _service = new EventService(_context, _cache);
        }

        // Test Case 1: Get all events
        [Test]
        public async Task GetAllEvents_ReturnsList()
        {
            // Arrange
            _context.Events.Add(new EventDetails
            {
                EventName = "Test Event",
                EventCategory = "IT",
                EventDate = DateTime.Now,
                Description = "Test",
                Status = "Active"
            });
            _context.SaveChanges();

            // Act
            var result = await _service.GetAllEvents(1, 5);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        // Test Case 2: Add event
        [Test]
        public async Task AddEvent_InsertsSuccessfully()
        {
            // Arrange
            var eventObj = new EventDetails
            {
                EventName = "New Event",
                EventCategory = "Tech",
                EventDate = DateTime.Now,
                Description = "Desc",
                Status = "Active"
            };

            // Act
            await _service.AddEvent(eventObj);

            // Assert
            var data = _context.Events.FirstOrDefault(e => e.EventName == "New Event");
            Assert.IsNotNull(data);
        }

        //  Test Case 3: Delete event
        [Test]
        public async Task DeleteEvent_RemovesRecord()
        {
            // Arrange
            var eventObj = new EventDetails
            {
                EventName = "Delete Event",
                EventCategory = "Tech",
                EventDate = DateTime.Now,
                Description = "Desc",
                Status = "Active"
            };

            _context.Events.Add(eventObj);
            _context.SaveChanges();

            // Act
            await _service.DeleteEvent(eventObj.EventId);

            // Assert
            var data = _context.Events.FirstOrDefault(e => e.EventId == eventObj.EventId);
            Assert.IsNull(data);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
          //(_cache as IDisposable)?.Dispose();
        }
    }
}