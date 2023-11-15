using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Entities;
using N71_Blog.Persistence.DataContexts;
using N71_Blog.Persistence.Repositories.Interface;

namespace N71_Blog.Persistence.Repositories;

public class BlogRepository : EntityRepositoryBase<Blog, BlogDbContext>, IBlogRepository
{
    public BlogRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(blog, saveChanges, cancellationToken);
    }

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = null, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(blog, saveChanges, cancellationToken);
    }
}
