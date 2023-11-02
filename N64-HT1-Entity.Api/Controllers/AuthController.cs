using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N64_HT1_Entity.Application.Common.Identity.Models;
using N64_HT1_Entity.Application.Common.Identity.Services;

namespace N64_HT1_Entity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        // Request.Headers.Authorization

        var result = await _authService.RegisterAsync(registrationDetails);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = await _authService.LoginAsync(loginDetails);
        return Ok(result);
    }
}
