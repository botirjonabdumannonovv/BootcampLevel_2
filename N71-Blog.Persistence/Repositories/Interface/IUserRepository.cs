using System.Linq.Expressions;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.Repositories.Interface;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellation = default);

    ValueTask<User> CreateAsync(User user,bool saveChanges = true,CancellationToken cancellation = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true,CancellationToken cancellation = default);
}
