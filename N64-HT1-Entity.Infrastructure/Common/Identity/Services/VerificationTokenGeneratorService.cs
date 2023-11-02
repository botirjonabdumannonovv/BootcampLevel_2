using Microsoft.Extensions.Options;
using N64_HT1_Entity.Application.Common.Enums;
using N64_HT1_Entity.Application.Common.Identity.Models;
using System.Text.Json;

using N64_HT1_Entity.Application.Common.Identity.Services;
using N64_HT1_Entity.Application.Common.Settings;
using Microsoft.AspNetCore.DataProtection;

namespace N64_HT1_Entity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _dataProtector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGeneratorService(IDataProtectionProvider dataProtectionProvider, IOptions<VerificationTokenSettings> verificationTokenSettings)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));

        var unprotectedToken = _dataProtector.Unprotect(token);

        var verificationToken = JsonSerializer.Deserialize<VerificationToken>(unprotectedToken)
            ?? throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public string GenerateToken(VerificationType type, Guid id)
    {
        return _dataProtector.Protect(JsonSerializer.Serialize(new VerificationToken
        {
            UserId = id,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        }));
    }
}
