﻿using N70_Entity.Application.Common.Identity.Models;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails, CancellationToken cancellationToken = default);

    ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default);

    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default);
}
