using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using UpgradEventAPI.Services;
using System.Security.Claims;
using UpgradEventAPI.Models;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _service;

    public ParticipantController(IParticipantService service)
    {
        _service = service;
    }

    //Participant -Register for Event
    [Authorize(Roles = "Participant")]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var email = User.FindFirst(ClaimTypes.Name)?.Value;

        // GET USER EVENTS
        var existingEvents = await _service.GetUserEvents(email);

        // CHECK DUPLICATE
        var alreadyRegistered = existingEvents.Any(x =>
            x.EventId == request.EventId &&
            x.SessionId == request.SessionId
        );

        if (alreadyRegistered)
        {
            return BadRequest("Already Registered");
        }

        var data = new ParticipantEventDetails
        {
            EventId = request.EventId,
            SessionId = request.SessionId,
            ParticipantEmailId = email,
            IsAttended = false
        };

        await _service.RegisterEvent(data);

        return Ok("Registered successfully");
    }

    //Participant - View My Events
    [Authorize(Roles = "Participant")]
    [HttpGet("my-events")]
    public async Task<IActionResult> MyEvents()
    {
        var email = User.FindFirst(ClaimTypes.Name)?.Value;

        var events = await _service.GetUserEvents(email);
        return Ok(events);
    }

    // Admin - Mark Attendance
    [Authorize(Roles = "Admin")]
    [HttpPut("attendance/{id}")]
    public async Task<IActionResult> MarkAttendance(int id)
    {
        await _service.MarkAttendance(id);
        return Ok("Attendance marked");
    }
}