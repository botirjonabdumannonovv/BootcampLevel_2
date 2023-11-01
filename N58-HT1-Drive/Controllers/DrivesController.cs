using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N58_HT1_Drive.Models;

namespace N58_HT1_Drive.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrivesController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetDrives()
    {
        var drivesInfo = DriveInfo.GetDrives();

        var drives = drivesInfo.Select(driveInfo => new StorageDrive
        {
            Name = driveInfo.Name.Substring(0, driveInfo.Name.IndexOf(':')),
            Path = driveInfo.Name,
            Format = driveInfo.DriveFormat,
            Type = driveInfo.DriveType.ToString(),
            TotalSpace = driveInfo.TotalSize,
            FreeSpace = driveInfo.AvailableFreeSpace,
            UnavailableSpace = driveInfo.TotalFreeSpace - driveInfo.AvailableFreeSpace,
            UsedSpace = driveInfo.TotalSize - driveInfo.TotalFreeSpace,
        });

        return new ValueTask<IActionResult>(Ok(drives));

    }
}
