using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Entities;
using N71_Blog.Persistence.DataContexts;
using N71_Blog.Persistence.Repositories.Interface;

namespace N71_Blog.Persistence.Repositories;

public class CommentRepository : EntityRepositoryBase<Comment, BlogsDbContext>, ICommentRepository
{
    public CommentRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = null, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(comment, saveChanges, cancellationToken);
    }
}
