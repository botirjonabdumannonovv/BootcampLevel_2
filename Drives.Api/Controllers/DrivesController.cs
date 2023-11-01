using Drives.Application.Common.Brokers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drives.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrivesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAllDrivesAsync([FromServices] IDriveBroker driveBroker)
    {
        var result = driveBroker.Get();
        return new ValueTask<IActionResult>(Ok(result));
    }
}
