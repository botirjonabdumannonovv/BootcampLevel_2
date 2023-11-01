using N58_HT1_Drive.Enums;

namespace N58_HT1_Drive.Models;

public class StorageDirectory
{
    public string Name { get; set; } = string.Empty;

    public int ItemsCount { get; set; }

    public string Path { get; set; } = string.Empty;

    public EntryType EntryType { get; set; } = EntryType.Directory;
}
