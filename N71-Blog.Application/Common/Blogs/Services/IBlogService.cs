using System.Linq.Expressions;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IBlogService
{
    IQueryable<Blog?> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<ICollection<Blog>> GetByIdAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);
   
    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true,CancellationToken cancellationToken = default);

    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true ,CancellationToken cancellationToken = default);
}
