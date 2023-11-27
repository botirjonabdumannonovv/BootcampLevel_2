using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N76_HT1_Interceptors.Api.Models.Dtos;
using N76_HT1_Interceptors.Application.Common.Identity.Services;
using N76_HT1_Interceptors.Domain.Entities;

namespace N76_HT1_Interceptors.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IMapper mapper,IUserService userService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var entity = await userService.Get().ToListAsync();
     
        return entity.Any() ? Ok(mapper.Map<IEnumerable<UserDto>>(entity)) : NotFound();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
    {
        var user = await userService.GetByIdAsync(userId);
        return user != null ? Ok(mapper.Map<UserDto>(user)) : NotFound(); 
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] UserDto user)
    {
        var createdUser = await userService.CreateAsync(mapper.Map<User>(user));
        return CreatedAtAction(
            nameof(GetById),
            new
            {
                userId = createdUser.Id,
            },
            mapper.Map<UserDto>(createdUser)
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] UserDto user)
    {
        var result =  await userService.UpdateAsync(mapper.Map<User>(user));
        return Ok();
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid userId)
    {
        await userService.DeleteByIdAsync(userId);
        return Ok();
    }
}
