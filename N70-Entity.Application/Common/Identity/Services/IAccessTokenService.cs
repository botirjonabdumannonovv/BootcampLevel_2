using N70_Entity.Domain.Entities;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true, CancellationToken cancellationToken = default);
}
