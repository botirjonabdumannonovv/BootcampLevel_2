using N64_HT1_Entity.Application.Common.Enums;

namespace N64_HT1_Entity.Application.Common.Identity.Models;

public class VerificationToken
{
    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }
}
