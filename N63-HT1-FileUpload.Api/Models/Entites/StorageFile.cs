using FileBaseContext.Abstractions.Models.Entity;

namespace N63_HT1_FileUpload.Api.Models.Entites;

public class StorageFile : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public string Extension { get; set; } = string.Empty;
}
