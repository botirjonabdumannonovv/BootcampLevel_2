namespace N67.EduCourse.Application.Common;

public interface IRoleService
{
    IEnumerable<Guid> GetStudents();
    IEnumerable<Guid> GetTeachers();
}
