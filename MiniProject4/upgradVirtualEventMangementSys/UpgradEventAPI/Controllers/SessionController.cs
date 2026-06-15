using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using UpgradEventAPI.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service)
    {
        _service = service;
    }

    // Admin only - Add Session
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Add(SessionInfo session)
    {
        await _service.AddSession(session);

        return Ok("Session added successfully");
    }

    // Public - View sessions by event
    [AllowAnonymous]
    [HttpGet("event/{eventId}")]
    public async Task<IActionResult> GetByEvent(int eventId)
    {
        var sessions =
            await _service.GetSessionsByEvent(eventId);

        return Ok(sessions);
    }

    // Public - View all sessions
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sessions =
            await _service.GetAllSessions();

        return Ok(sessions);
    }

    // Admin only - Delete Session
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        await _service.DeleteSession(id);

        return Ok("Session deleted");
    }
}