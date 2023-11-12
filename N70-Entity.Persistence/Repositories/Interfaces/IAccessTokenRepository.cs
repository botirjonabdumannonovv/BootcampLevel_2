using N70_Entity.Domain.Entities;

namespace N70_Entity.Persistence.Repositories.Interfaces;

public interface IAccessTokenRepository
{
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellation = default);
}
