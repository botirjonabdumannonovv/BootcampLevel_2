using N70_Entity.Domain.Entities;
using N70_Entity.Domain.Enums;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking = false, CancellationToken cancellationToken = default);   
}
