using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Domain.Entities;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<User>> Get(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _userRepository
            .Get(asNoTracking:asNoTracking)
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken );
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }
}
