namespace N71_Blog.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string VerificationTokenPurpose { get; set; } = default!;

    public int VerificationExpirationDurationInMinutes { get; set; } = default!;
}
