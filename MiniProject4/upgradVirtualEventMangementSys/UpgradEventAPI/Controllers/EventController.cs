using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using UpgradEventAPI.Services;
using UpgradEventAPI.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/v1/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _service;

    public EventController(IEventService service)
    {
        _service = service;
    }

    // GET ALL EVENTS (PUBLIC)
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 50)
    {
        var events =
            await _service.GetAllEvents(page, pageSize);

        return Ok(events);
    }

    // GET EVENT BY ID (PUBLIC)
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var eventData =
            await _service.GetEventById(id);

        if (eventData == null)
            return NotFound("Event not found");

        return Ok(eventData);
    }

    // CREATE EVENT
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateEventRequest request)
    {
        if (!DateTime.TryParse(
            request.EventDate,
            out DateTime parsedDate))
        {
            return BadRequest("Invalid date format");
        }

        var eventDetails = new EventDetails
        {
            EventName = request.EventName,
            EventCategory = request.EventCategory,
            EventDate = parsedDate,
            Description = request.Description,
            Status = request.Status
        };

        await _service.AddEvent(eventDetails);

        return Ok("Event created successfully");
    }

    // DELETE EVENT
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteEvent(id);

        return Ok("Event deleted successfully");
    }

    // UPDATE EVENT
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateEventRequest request)
    {
        var eventData =
            await _service.GetEventById(id);

        if (eventData == null)
        {
            return NotFound("Event not found");
        }

        eventData.EventName =
            request.EventName;

        eventData.EventCategory =
            request.EventCategory;

        eventData.Description =
            request.Description;

        eventData.Status =
            request.Status;

        if (DateTime.TryParse(
            request.EventDate,
            out DateTime parsedDate))
        {
            eventData.EventDate =
                parsedDate;
        }

        await _service.UpdateEvent(eventData);

        return Ok("Event updated successfully");
    }
}