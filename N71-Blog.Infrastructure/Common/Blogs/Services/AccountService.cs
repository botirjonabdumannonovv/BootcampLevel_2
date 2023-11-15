using N71_Blog.Application.Common.Blogs.Services;
using N71_Blog.Application.Common.Enums;
using N71_Blog.Domain.Entities;

namespace N71_Blog.Infrastructure.Common.Blogs.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGenerator;
    private readonly IUserService _userService;

    public AccountService(
        IVerificationTokenGeneratorService verificationTokenGenerator,
        IUserService userService
        )
    {
        _verificationTokenGenerator = verificationTokenGenerator;
        _userService = userService;
    }


    public async ValueTask<User> CreateUserAsync(User user, CancellationToken cancellation = default)
    {
        var createdUser = await _userService.CreateAsync(user, true, cancellation);



        return createdUser;
    }

    public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellation = default)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentNullException(nameof(token));
        }
        var verificationTokenResult = _verificationTokenGenerator.DecodeToken(token);

        if (!verificationTokenResult.IsValid)
        {
            throw new InvalidOperationException("Invalid verification token");
        }
        var result = verificationTokenResult.token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.token.UserId),
            _ => throw new InvalidOperationException("Invalid process!")
        };
        return result;
    }
    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        return new(true);
    }
}
