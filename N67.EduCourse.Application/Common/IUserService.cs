using N67.EduCourse.Domain.Entities;

namespace N67.EduCourse.Application.Common;

public interface IUserService
{
    public IQueryable<User> Get();
    public IQueryable<User> Get(IEnumerable<Guid> ids);
    public ValueTask<User> GetById(Guid id);
    public ValueTask<User> Create(User user);
}
