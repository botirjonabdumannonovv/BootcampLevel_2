﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N62_HT1.Api.Models;
using N62_HT1.Api.Services;

namespace N62_HT1.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthController(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    [HttpPost("login")]
    public ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = loginDetails.EmailAddress,
            Password = loginDetails.Password,
        };

        var token = _tokenGeneratorService.GetToken(user);

        return new ValueTask<IActionResult>(Ok(token));
    }
}
