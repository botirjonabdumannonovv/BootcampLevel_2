using System.Linq.Expressions;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface ICommentService
{

    IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate = default, bool asNoTracking = false);

    ValueTask<Comment?> GetByIdAsync(Guid commentId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true,CancellationToken cancellationToken = default);

    ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Comment> DeleteAsync(Comment comment,bool saveChanges = true, CancellationToken cancellation = default);
}
