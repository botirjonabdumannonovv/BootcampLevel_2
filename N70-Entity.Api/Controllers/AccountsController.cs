using Microsoft.AspNetCore.Mvc;

using N70_Entity.Application.Common.Identity.Services;

namespace N70_Entity.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
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
