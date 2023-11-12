using System.Linq.Expressions;

using N70_Entity.Domain.Entities;

namespace N70_Entity.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellation = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true,CancellationToken cancellation = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);

}
