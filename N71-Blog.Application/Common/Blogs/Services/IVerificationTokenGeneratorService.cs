using N71_Blog.Application.Common.Blogs.Models;
using N71_Blog.Application.Common.Enums;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type,Guid userId);

    (VerificationToken token, bool IsValid) DecodeToken(string token);
}
