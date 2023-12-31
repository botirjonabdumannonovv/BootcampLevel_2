﻿using N58_HT1_Drive.Enums;

namespace N58_HT1_Drive.Models;

public class StorageDrive
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public EntryType EntryType { get; set; } = EntryType.Drive;
}
