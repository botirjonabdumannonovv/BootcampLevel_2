using FileBaseContext.Abstractions.Models.Entity;

namespace N63_HT1_FileUpload.Api.Models.Entites;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
