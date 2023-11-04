using N67.EduCourse.Application.Common;
using N67.EduCourse.Persistence.DataContext;

namespace N67.EduCourse.Infrastructure.Common;

public class RoleService : IRoleService
{
    private readonly AppDataContext _dbContext;

    public RoleService(AppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Guid> GetStudents()
    {
        return _dbContext.Roles.ToList()
            .Where(role => role.Name.Contains("stud", StringComparison.OrdinalIgnoreCase))
            .Select(role => role.UserId);
    }

    public IEnumerable<Guid> GetTeachers()
    {
        return _dbContext.Roles.ToList()
            .Where(role => role.Name.Contains("teach", StringComparison.OrdinalIgnoreCase))
            .Select(role => role.UserId);
    }
}
