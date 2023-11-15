using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetSecurityToken(User user);

    List<Claim> GetClaims(User user);
}
