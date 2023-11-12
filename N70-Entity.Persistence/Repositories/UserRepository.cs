using Microsoft.EntityFrameworkCore;

using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.DataContexts;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, IdentityDbContext>, IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
}

