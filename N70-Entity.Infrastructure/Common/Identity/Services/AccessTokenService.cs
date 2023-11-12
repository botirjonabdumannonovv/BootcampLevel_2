using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly IAccessTokenRepository _accessTokenRepository;

    public AccessTokenService(IAccessTokenRepository accessTokenRepository)
    {
        _accessTokenRepository = accessTokenRepository;
    }

    public async ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var accessToken = new AccessToken()
        {
            UserId = userId,
            Value = value
        };
        await _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);

        return accessToken;
    }

    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken= default)
    {
        return _accessTokenRepository.CreateAsync(accessToken,saveChanges, cancellationToken);
    }
}

