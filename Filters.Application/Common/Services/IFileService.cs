using Filters.Application.Common.Models;

namespace Filters.Application.Common.Services;

public interface IFileService
{
    List<StorageFileFilterModel> GetListAllFiles();
    List<StorageFileFilterModel> FileFilteringLogic(StorageFileFilterModel filter);
}
