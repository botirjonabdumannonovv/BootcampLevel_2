using N64_HT1_Entity.Domain.Entites;
namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<User> CreateUserAsync(User user);

    ValueTask<bool> VerificateAsync(string token);
}
