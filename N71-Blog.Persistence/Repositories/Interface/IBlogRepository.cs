using System.Linq.Expressions;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.Repositories.Interface;

public interface IBlogRepository
{
    IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate, bool asNoTracking = false);

    ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);
}
