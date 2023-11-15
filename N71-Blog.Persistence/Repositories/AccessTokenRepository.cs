using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Entities;
using N71_Blog.Persistence.DataContexts;
using N71_Blog.Persistence.Repositories.Interface;

namespace N71_Blog.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, BlogDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(accessToken, saveChanges, cancellationToken);
    }
}
