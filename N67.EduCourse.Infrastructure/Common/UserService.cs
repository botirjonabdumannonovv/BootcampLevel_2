using N67.EduCourse.Application.Common;
using N67.EduCourse.Domain.Entities;
using N67.EduCourse.Persistence.DataContext;

namespace N67.EduCourse.Infrastructure.Common;

public class UserService:IUserService
{
    private readonly AppDataContext _dbContext;

    public UserService(AppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<User> Create(User user)
    {
        await _dbContext.AddAsync(user);

        await _dbContext.SaveChangesAsync();

        return user;
    }

    public IQueryable<User> Get()
    {
        return _dbContext.Users;
    }

    public IQueryable<User> Get(IEnumerable<Guid> ids)
    {
        return _dbContext.Users.Where(user => ids.Contains(user.Id));
    }

    public ValueTask<User> GetById(Guid id) => new(_dbContext.Users.FirstOrDefault(x => x.Id == id));
}
