using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using N64_HT1_Entity.Domain.Entites;

namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);
}

