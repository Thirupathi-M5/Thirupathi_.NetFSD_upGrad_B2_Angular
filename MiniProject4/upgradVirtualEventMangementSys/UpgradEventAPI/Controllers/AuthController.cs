using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpgradEventAPI.Models;
using UpgradEventAPI.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.Login(request.EmailId, request.Password);

        if (token == null)
            return Unauthorized("Invalid credentials");

        return Ok(new { Token = token });
    }

    
}