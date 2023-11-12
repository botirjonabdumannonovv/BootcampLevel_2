using System.Linq.Expressions;

using N70_Entity.Domain.Entities;

namespace N70_Entity.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);
}
