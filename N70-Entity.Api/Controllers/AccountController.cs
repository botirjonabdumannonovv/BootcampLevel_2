using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N70_Entity.Application.Common.Identity.Services;

namespace N70_Entity.Apii.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
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
