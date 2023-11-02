using Library.Application.Common.Entity.Services;
using Library.Domain.Entites.Models;
using Library.Infrastructure.Common.Entity.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("books")]
    public async Task<IActionResult> Create([FromBody] Book book)
        => Ok(await _bookService.CreateAsync(book, true));

    [HttpGet("books/bookId:guid")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
      => Ok(await _bookService.GetByIdAsync(id));

    [HttpPut("books")]
    public async Task<IActionResult> Update([FromBody] Book book)
    {
        Ok(await _bookService.UpdateAsync(book, true));
        return NoContent();
    }

    [HttpDelete("books/bookId:guid")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Ok(await _bookService.DeleteByIdAsync(id, true));
        return NoContent();
    }
}
