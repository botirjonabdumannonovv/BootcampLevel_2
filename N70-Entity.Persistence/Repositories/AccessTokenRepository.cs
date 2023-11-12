using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.DataContexts;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext dbContext):base(dbContext)
    {
        
    }
    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellation = default)
    {
        return base.CreateAsync(accessToken, saveChanges, cancellation);
    }
}
