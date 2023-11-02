using BC = BCrypt.Net.BCrypt;
namespace N63_HT1_FileUpload.Api.Services;

public class PasswordHasherService
{
    public string Hash(string password) => BC.HashPassword(password);

    public bool Verify(string password, string hash) => BC.Verify(password, hash);
}
