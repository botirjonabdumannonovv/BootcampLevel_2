namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class PasswordGeneratorService
{
    private static Random random = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

    public string GeneratePassword(int length)
    {
        return new string(Enumerable.Repeat(Chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
    }

    public bool ValidatePassword(string password)
    {
        if(password.Length < 8)
        {
            return false;
        }
        if(!password.Any(char.IsUpper) ) 
        {
            return false;
        }
        if (!password.Any(char.IsDigit))
        {
            return false;
        }
        if(!password.Any(ch => !char.IsLetterOrDigit(ch)) ) 
        {
            return false;
        }
        return true;
    }

}
