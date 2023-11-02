using N63_HT1_FileUpload.Api.Models.Entites;

namespace N63_HT1_FileUpload.Api.Interfaces;

public interface IUserService
{
    ValueTask<User> CreateAsync(User user);

    ValueTask<User> GetByIdAsync(Guid id);

    IQueryable<User> GetAll();
}
