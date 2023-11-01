using Filters.Application.Common.Models;
using Filters.Infrastructure.Services;

using Microsoft.AspNetCore.Mvc;

namespace Filters.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetFilteredFilesAsync([FromQuery] StorageFileFilterModel storageFileFilterModel, [FromServices]FileService fileService)
    {
        var result = fileService.FileFilteringLogic(storageFileFilterModel);
        return new ValueTask<IActionResult>(Ok(result));
    }
}
