using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IBlogerService
{
    ValueTask<IQueryable<User>> GetPopularBlogers(User user, bool saveChanges = true, CancellationToken cancellationToken = default); 
}
