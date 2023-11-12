using N70_Entity.Domain.Entities;

namespace N70_Entity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default);

    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default); 
}
