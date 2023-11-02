namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool Verify(string password, string hash);
}
