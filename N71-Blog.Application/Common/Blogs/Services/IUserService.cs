using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IUserService
{
    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking  = false, CancellationToken cancellation = default);

    ValueTask<User> CreateAsync(User user,bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<User> DeleteAsync(User user,bool saveChanges = true,CancellationToken cancellation = default);
}
