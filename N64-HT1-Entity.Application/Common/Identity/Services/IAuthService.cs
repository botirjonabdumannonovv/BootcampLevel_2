using N64_HT1_Entity.Application.Common.Identity.Models;

namespace N64_HT1_Entity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}
