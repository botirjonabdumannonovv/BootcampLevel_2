
using N70_Entity.Application.Common.Enums;
using N70_Entity.Application.Common.Identity.Models;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}
