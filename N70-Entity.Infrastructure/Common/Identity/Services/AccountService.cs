using N70_Entity.Application.Common.Enums;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Application.Common.Notifications.Services;
using N70_Entity.Domain.Entities;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationToken;
    private readonly IEmailOrchestrationService _emailOrchestration;
    private readonly IUserService _userService;

    public AccountService(IVerificationTokenGeneratorService verificationToken,IEmailOrchestrationService emailOrchestration,IUserService userService)
    {
        _verificationToken = verificationToken;
        _emailOrchestration = emailOrchestration;
        _userService = userService;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        var createdUser = await _userService.CreateAsync(user,true, cancellationToken);

        var verificationToken = _verificationToken.GenerateToken(VerificationType.EmailAddressVerification, createdUser.Id);

        var verificationEmailResult = await _emailOrchestration.SendAsync(createdUser.EmailAddress, $"Welcome to system - {verificationToken}");

        var result = verificationEmailResult;

        return result;
    }

    public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default)
    {
        if(string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("Invalid verification token",nameof(token));
        }
        var verificationTokenResult = _verificationToken.DecodeToken(token);
        if(!verificationTokenResult.IsValid)
        {
            throw new InvalidOperationException("Invalid verification token");
        }
        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("Invalid bro!")
        };
        
        return result;
    }

    private ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        return new ValueTask<bool>(true);
    }
}
