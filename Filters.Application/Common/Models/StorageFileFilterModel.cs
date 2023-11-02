namespace Filters.Application.Common.Models;

public class StorageFileFilterModel : IStorageEntry
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string? DirectoryPath { get; set; }

    public long Size { get; set; }

    public string Extention { get; set; } = string.Empty;

    public StorageEntryType EntryType { get; set; }
}
