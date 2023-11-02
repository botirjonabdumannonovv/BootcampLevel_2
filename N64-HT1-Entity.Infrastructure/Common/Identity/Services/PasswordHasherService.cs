using N64_HT1_Entity.Application.Common.Identity.Services;

using BC = BCrypt.Net.BCrypt;
namespace N64_HT1_Entity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password) => BC.HashPassword(password);

    public bool Verify(string password, string hash) => BC.Verify(password, hash);
}
