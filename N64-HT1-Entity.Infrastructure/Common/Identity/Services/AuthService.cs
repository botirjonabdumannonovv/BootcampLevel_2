using System.Security.Authentication;

using N64_HT1_Entity.Application.Common.Identity.Models;
using N64_HT1_Entity.Application.Common.Identity.Services;
using N64_HT1_Entity.Application.Common.Notifications.Services;
using N64_HT1_Entity.Domain.Entites;

namespace N64_HT1_Entity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AuthService(ITokenGeneratorService tokenGeneratorService, IPasswordHasherService passwordHasherService, IAccountService accountService, IEmailOrchestrationService emailOrchestrationService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
    }


    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password)
        };

        await _accountService.CreateUserAsync(user);

        var verificationEmailResult = await _emailOrchestrationService.SendAsync(registrationDetails.EmailAddress, "Sistemaga xush kelibsiz");

        return verificationEmailResult;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress && user.PasswordHash == loginDetails.Password);

        if (foundUser is null || !_passwordHasherService.Verify(loginDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new(accessToken);
    }
}
