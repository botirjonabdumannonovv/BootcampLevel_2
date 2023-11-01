using N58_HT1_Drive.Enums;

namespace N58_HT1_Drive.Models;

public class IStorageBase
{
    string Name { get; set; }

    string Path { get; set; }

    EntryType EntryType { get; set; }
}
