using N71_Blog.Persistence.DataContexts;
using N71_Blog.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N71_Blog.Persistence.Repositories.Interface;

namespace N71_Blog.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, BlogsDbContext>, IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        return base.CreateAsync(user, saveChanges, cancellation);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellation);
    }

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellation)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellation);
    }
}
