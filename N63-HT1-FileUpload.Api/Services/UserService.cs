using N63_HT1_FileUpload.Api.DataAccess;
using N63_HT1_FileUpload.Api.Interfaces;
using N63_HT1_FileUpload.Api.Models.Entites;

namespace N63_HT1_FileUpload.Api.Services;

public class UserService : IUserService
{
    private readonly IDataContext _context;

    public UserService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        Validate(user);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public IQueryable<User> GetAll()
        => _context.Users.AsQueryable();

    public ValueTask<User> GetByIdAsync(Guid id)
        => new ValueTask<User>(_context.Users.FirstOrDefault(user => user.Id == id)!);

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentException("not valid");

        if (!user.Email.EndsWith("@gmail.com"))
            throw new Exception();
    }
}
