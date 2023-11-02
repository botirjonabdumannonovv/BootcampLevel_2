using System.Linq.Expressions;

using N64_HT1_Entity.Domain.Entites;

namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true,CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken= default);

    ValueTask DeleteAsync(User user,bool saveChanges = true,CancellationToken cancellationToken= default);

}
