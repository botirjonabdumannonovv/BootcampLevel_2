using N71_Blog.Domain.Entities;

namespace N71_Blog.Application.Common.Blogs.Services;

public interface IAccountService
{
    ValueTask<bool> VerificateAsync(string token, CancellationToken cancellation = default);

    ValueTask<User> CreateUserAsync(User user, CancellationToken cancellation = default);
}
