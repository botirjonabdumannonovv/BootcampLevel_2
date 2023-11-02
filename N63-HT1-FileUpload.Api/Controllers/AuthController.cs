﻿using Mapster;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N63_HT1_FileUpload.Api.Interfaces;
using N63_HT1_FileUpload.Api.Models.Dtos;
using N63_HT1_FileUpload.Api.Models.Entites;
using N63_HT1_FileUpload.Api.Services;

namespace N63_HT1_FileUpload.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenGeneratorService _tokenGeneratorService;
    private readonly PasswordHasherService _passwordHasherService;
    private readonly IUserService _userService;

    public AuthController(TokenGeneratorService tokenGeneratorService, PasswordHasherService passwordHasherService, IUserService userService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _userService = userService;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var user = registrationDetails.Adapt<User>();
        user.Id = Guid.NewGuid();
        user.Password = _passwordHasherService.Hash(user.Password);

        await _userService.CreateAsync(user);

        return Ok();
    }

    [HttpPost("login")]
    public ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var found = _userService.GetAll().FirstOrDefault(user => user.Email == loginDetails.Email && _passwordHasherService.Verify(loginDetails.Password, user.Password))
                ?? throw new ArgumentException("Invalid email or password!");

        var token = _tokenGeneratorService.GetToken(found!);

        return new ValueTask<IActionResult>(Ok(token));

    }
}
