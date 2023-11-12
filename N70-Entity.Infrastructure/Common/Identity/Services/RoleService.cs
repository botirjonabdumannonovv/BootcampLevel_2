using Microsoft.EntityFrameworkCore;

using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Domain.Entities;
using N70_Entity.Domain.Enums;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _roleRepository.Get(asNoTracking: asNoTracking).SingleOrDefaultAsync(role => role.Type == roleType , cancellationToken); ;
    }
}
