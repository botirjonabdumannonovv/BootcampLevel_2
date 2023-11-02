using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N64_HT1_Entity.Application.Common.Identity.Services;

namespace N64_HT1_Entity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {
        var result = await _accountService.VerificateAsync(token);
        return Ok(result);
    }
}
