using Drives.Application.Common.Models;

using Filters.Application.Common.Models;
using Filters.Application.Common.Services;

namespace Filters.Infrastructure.Services;

public class FileService : IFileService
{
    public List<StorageFileFilterModel> GetListAllFiles()
    {
        string directoryPath = "D:\\Bootcamp  .NET\\BootcampLevel2\\bin\\Debug\\net7.0\\User";
        var directoryInfo = new DirectoryInfo(directoryPath);

        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException("Directory path not found");
        }
        List<StorageFileFilterModel> allFiles = directoryInfo.GetFiles()
            .Select(fileInfo => new StorageFileFilterModel
            {
                Name = fileInfo.Name,
                DirectoryPath = directoryPath,
                EntryType = StorageEntryType.File
            }).ToList();

        return allFiles;
    }


    public List<StorageFileFilterModel> FileFilteringLogic(StorageFileFilterModel filter)
    {
        List<StorageFileFilterModel> allFiles = GetListAllFiles(); // Barcha fayllarni olish

        if (filter != null)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                allFiles = allFiles.Where(f => f.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(filter.DirectoryPath))
            {
                allFiles = allFiles.Where(f =>
                {
                    return f.DirectoryPath
                    .Equals(filter.DirectoryPath, StringComparison.OrdinalIgnoreCase);
                }).ToList();
            }

            if (filter.Size > 0)
            {
                allFiles = allFiles.Where(f => f.Size >= filter.Size).ToList();
            }

            if (filter.EntryType != StorageEntryType.OtherType)
            {
                allFiles = allFiles.Where(f => f.EntryType == filter.EntryType).ToList();
            }
        }
        return allFiles;
    }
}
