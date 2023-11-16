using System.Linq.Expressions;

using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Domain.Entities;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class UserService : IUserService
{
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User?> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}
