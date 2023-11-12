using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

using N70_Entity.Application.Common.Enums;
using N70_Entity.Application.Common.Identity.Models;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Application.Common.Settings;

using Newtonsoft.Json;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly VerificationTokenSettings _verificationTokenSettings;
    private readonly IDataProtector _dataProtectionProvider;

    public VerificationTokenGeneratorService(
        IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider
        )
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtectionProvider = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        if(string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentNullException(nameof(token));
        }
        var unprotectedToken = _dataProtectionProvider.Unprotect(token);

        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken)??
            throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };
        return _dataProtectionProvider.Protect(JsonConvert.SerializeObject(verificationToken));
    }
}
