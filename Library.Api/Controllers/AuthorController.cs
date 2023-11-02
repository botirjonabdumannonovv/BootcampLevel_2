using Library.Application.Common.Entity.Services;
using Library.Domain.Entites.Models;
using Library.Infrastructure.Common.Entity.Services;

using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }


    [HttpPost("authors")]
    public async Task<IActionResult> CreateAsync([FromBody] Author author)
    {
        var createdAuthor = await _authorService.CreateAsync(author, true);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpGet("authors/auhtorId:guid")]
    public async Task<IActionResult> GetByIdAsync(Guid authorId)
      => Ok(await _authorService.GetByIdAsync(authorId));

    [HttpPut("auhtors")]
    public async Task<IActionResult> Update([FromBody] Author author)
    {
        Ok(await _authorService.UpdateAsync(author, true));
        return NoContent();
    }

    [HttpDelete("authors/auhtorId:guid")]
    public async Task<IActionResult> Delete(Guid authorId)
    {
        Ok(await _authorService.DeleteByIdAsync(authorId, true));
        return NoContent();
    }
}
