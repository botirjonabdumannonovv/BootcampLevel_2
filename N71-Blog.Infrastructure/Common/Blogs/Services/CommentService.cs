using System.Linq.Expressions;

using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Domain.Entities;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class CommentService : ICommentService
{
    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment?> GetByIdAsync(Guid commentId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
