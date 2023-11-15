using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.Repositories.Interface;

public interface IAccessTokenRepository
{
    ValueTask<AccessToken> CreateAsync(
        AccessToken accessToken, 
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        );
}
