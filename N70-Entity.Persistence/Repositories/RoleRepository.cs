using System.Linq.Expressions;

using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.DataContexts;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role, IdentityDbContext>, IRoleRepository
{
    public RoleRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }
}