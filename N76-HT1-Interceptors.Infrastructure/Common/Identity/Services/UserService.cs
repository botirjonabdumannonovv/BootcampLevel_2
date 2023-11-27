using System.Linq.Expressions;
using N76_HT1_Interceptors.Application.Common.Identity.Services;
using N76_HT1_Interceptors.Domain.Entities;
using N76_HT1_Interceptors.Persistence.Repositories.Interfaces;

namespace N76_HT1_Interceptors.Infrastructure.Common.Identity.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(user.Id, true, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException();

        foundUser.FirstName = user.FirstName;

        return await userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(userId, saveChanges, cancellationToken);
    }
}
