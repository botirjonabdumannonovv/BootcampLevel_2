using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N58_HT1_Drive.Models;

namespace N58_HT1_Drive.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectoriesController : ControllerBase
{
    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetEntries([FromQuery] FilterModel filterModel, [FromServices] IWebHostEnvironment environment)
    {
        var entries = new List<IStorageBase>();
        var directoryInfo = new DirectoryInfo(environment.WebRootPath);

        await Task.Run(() =>
        {
            if (filterModel.IncludeDirectories)
            {

                entries.AddRange(
                    (IEnumerable<IStorageBase>)directoryInfo.GetDirectories().Select(dirInfo =>
                    {
                        var storageDirectory = new StorageDirectory();

                        storageDirectory.Name = dirInfo.Name;

                        storageDirectory.ItemsCount = dirInfo.GetFileSystemInfos().Count();

                        storageDirectory.Path = dirInfo.FullName;

                        return storageDirectory;
                    }));
            }

            if (filterModel.IncludeFiles)
            {
                entries.AddRange(
                    (IEnumerable<IStorageBase>)directoryInfo.GetFiles().Select(fileInfo =>
                    {
                        var storageFile = new StorageFile();

                        storageFile.Name = fileInfo.Name;

                        storageFile.Directory = fileInfo.DirectoryName!;

                        storageFile.Path = fileInfo.FullName;

                        storageFile.Extension = fileInfo.Extension;

                        storageFile.Size = fileInfo.Length;

                        return storageFile;
                    })
                    );
            }

            entries = entries.Skip((filterModel.PageToken - 1) * filterModel.PageSize).Take(filterModel.PageSize).ToList();
        });

        return entries.Any() ? Ok(entries) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntries([FromRoute] string directoryPath)
    {
        var entries = new List<IStorageBase>();
        var directoryInfo = new DirectoryInfo(directoryPath);

        await Task.Run(() =>
        {

            entries.AddRange(
                (IEnumerable<IStorageBase>)directoryInfo.GetDirectories().Select(dirInfo =>
                {
                    var storageDirectory = new StorageDirectory();

                    storageDirectory.Name = dirInfo.Name;

                    storageDirectory.ItemsCount = dirInfo.GetFileSystemInfos().Count();

                    storageDirectory.Path = dirInfo.FullName;

                    return storageDirectory;
                }));

            entries.AddRange(
                (IEnumerable<IStorageBase>)directoryInfo.GetFiles().Select(fileInfo =>
                {
                    var storageFile = new StorageFile();

                    storageFile.Name = fileInfo.Name;

                    storageFile.Directory = fileInfo.DirectoryName!;

                    storageFile.Path = fileInfo.FullName;

                    storageFile.Extension = fileInfo.Extension;

                    storageFile.Size = fileInfo.Length;

                    return storageFile;
                })
                );
        });

        return entries.Any() ? Ok(entries) : NoContent();
    }
}
