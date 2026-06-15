using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using UpgradEventAPI.Services;
using UpgradeEventAPI.Models;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class SpeakerController : ControllerBase
{
    private readonly ISpeakerService _service;

    public SpeakerController(ISpeakerService service)
    {
        _service = service;
    }

    // All logged-in users
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var speakers = await _service.GetAllSpeakers();
        return Ok(speakers);
    }

    // Admin only
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateSpeakerRequest request)
    {
        var speaker = new SpeakerDetails
        {
            SpeakerName = request.SpeakerName
        };

        await _service.AddSpeaker(speaker);

        return Ok(speaker);
    }

    // Admin only
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteSpeaker(id);
        return Ok("Speaker deleted");
    }
}