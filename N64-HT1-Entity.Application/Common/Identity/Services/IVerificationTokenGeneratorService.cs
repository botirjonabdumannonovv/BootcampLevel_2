using N64_HT1_Entity.Application.Common.Enums;
using N64_HT1_Entity.Application.Common.Identity.Models;

namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type, Guid id);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}
