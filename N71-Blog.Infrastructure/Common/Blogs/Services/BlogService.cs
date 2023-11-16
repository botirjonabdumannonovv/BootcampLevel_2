using System.Linq.Expressions;

using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Domain.Entities;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class BlogService : IBlogService
{
    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Blog?> Get(Expression<Func<Blog, bool>>? predicate = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<Blog>> GetByIdAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
