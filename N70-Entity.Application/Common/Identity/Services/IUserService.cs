using System.Linq.Expressions;

using N70_Entity.Domain.Entities;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IUserService
{
    ValueTask<ICollection<User>> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges =  true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(User user,bool saveChanges = true , CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
