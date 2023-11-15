using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(
        Guid userId,
        string value,
        bool saveChanges = true,
        CancellationToken cancellation = default
        );
}
