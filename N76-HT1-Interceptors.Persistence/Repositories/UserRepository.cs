using System.Linq.Expressions;
using N76_HT1_Interceptors.Domain.Entities;
using N76_HT1_Interceptors.Persistence.DataContexts;
using N76_HT1_Interceptors.Persistence.Repositories.Interfaces;

namespace N76_HT1_Interceptors.Persistence.Repositories;

public class UserRepository(InterceptorDbContext dbContext) : EntityRepositoryBase<User, InterceptorDbContext>(dbContext), IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }


    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
    public ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(userId, saveChanges, cancellationToken);
    }
}
