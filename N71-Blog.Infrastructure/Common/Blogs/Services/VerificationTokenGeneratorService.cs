using System.Text.Json;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

using N71_Blog.Application.Common.Blogs.Models;
using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Application.Common.Enums;
using N71_Blog.Application.Common.Settings;

using Newtonsoft.Json;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly VerificationTokenSettings _verificationToken;
    private readonly IDataProtector _protector;

    public VerificationTokenGeneratorService(
        IOptions<VerificationTokenSettings> verificationToken,
        IDataProtectionProvider dataProtection
        )
    {
        _verificationToken = verificationToken.Value;
        _protector = dataProtection.CreateProtector(_verificationToken.VerificationTokenPurpose);
    }
    public (VerificationToken token, bool IsValid) DecodeToken(string token)
    {
        if(string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentNullException(nameof(token));
        }
        var unProtectedToken = _protector.Unprotect(token);

        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unProtectedToken) ??
            throw new ArgumentException("Ivalid Verification Model", nameof(token));

        return new(verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationToken.VerificationExpirationDurationInMinutes)
        };

        return _protector.Protect(JsonConvert.SerializeObject(verificationToken));
    }
}
