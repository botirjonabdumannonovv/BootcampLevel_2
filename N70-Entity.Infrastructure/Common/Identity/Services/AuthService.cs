using System.Security.Authentication;

using Microsoft.AspNetCore.Http;

using N70_Entity.Application.Common.Identity.Models;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Application.Common.Notifications.Services;
using N70_Entity.Domain.Entities;
using N70_Entity.Domain.Enums;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccessTokenService _accessTokenService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IAccountService _accountService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(
        IRoleService roleService,
        IUserService userService,
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IAccessTokenService accessTokenService,
        IEmailOrchestrationService emailOrchestrationService,
        IAccountService accountService,
        IHttpContextAccessor httpContextAccessor

        )
    {
        _roleService = roleService;
        _userService = userService;
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _accessTokenService = accessTokenService;
        _emailOrchestrationService = emailOrchestrationService;
        _accountService = accountService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        var actionsUserId = await _userService.GetByIdAsync(actionUserId) ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType roleValue)) throw new InvalidOperationException();
        var role = await _roleService.GetByTypeAsync(roleValue)?? throw new InvalidOperationException();

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user);

        return true;

    }

    public async ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default)
    {
        var foundUser = await _userService.GetByEmailAddressAsync(loginDetails.EmailAddress, true, cancellationToken);

        if(foundUser is null || 
            !_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash)) 
            throw new AuthenticationException("Login details invalid!");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        await _accessTokenService.CreateAsync(foundUser.Id, accessToken,cancellationToken:cancellationToken);

        return accessToken;
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails, CancellationToken cancellationToken = default)
    {
        var foundUser = await _userService.GetByEmailAddressAsync(registrationDetails.EmailAddress, true, cancellationToken);

        if( foundUser is not null)
        {
            throw new InvalidOperationException("User details already exist!");
        }
        var defaultRole = await _roleService.GetByTypeAsync(RoleType.Guest, true, cancellationToken) ??
            throw new InvalidOperationException("Role doesn't exist!");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password),
            RoleId = defaultRole.Id,
        };
        return await _accountService.CreateUserAsync(user, cancellationToken:cancellationToken);
    }
}
