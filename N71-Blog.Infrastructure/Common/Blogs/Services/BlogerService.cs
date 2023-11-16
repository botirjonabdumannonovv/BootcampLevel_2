using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Domain.Entities;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class BlogerService : IBlogerService
{
    public ValueTask<IQueryable<User>> GetPopularBlogers(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
