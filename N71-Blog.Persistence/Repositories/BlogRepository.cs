using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Entities;
using N71_Blog.Persistence.DataContexts;
using N71_Blog.Persistence.Repositories;
using N71_Blog.Persistence.Repositories.Interface;

public class BlogRepository : EntityRepositoryBase<Blog, BlogsDbContext>, IBlogRepository
{
    public BlogRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public IQueryable<Blog> Get(Expression<Func<Blog, bool >> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(ids, asNoTracking, cancellationToken);
    }
}
