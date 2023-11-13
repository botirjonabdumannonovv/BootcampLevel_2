using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.DataContexts;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<AccessToken> CreateAsync(AccessToken token, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(token, saveChanges, cancellationToken);
    }
}