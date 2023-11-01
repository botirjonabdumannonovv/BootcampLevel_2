namespace Drives.Application.Common.Models;

public interface IStorageEntry
{
    string Name { get; set; }
    string Path { get; set; }
    StorageEntryType EntryType { get; set; }
}
